using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common;
using Bugeto_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Bugeto_Store.Application.Services.Products.Queries.GetProductForSite
{
    public class GetProductForSiteService : IGetProductForSiteService
    {
        private readonly IDatabaseContext _context;
        public GetProductForSiteService(IDatabaseContext context)
        {
            _context = context;
        }


        public ResultDto<ResultProductForSiteDto> Execute(string SearchKey,long? CatId, int Page)
        {
            int totalRow = 0;
            var productQuery = _context.Products
                .Include(p => p.ProductImages).AsQueryable();
            if (CatId != null)
            {
                productQuery = productQuery.Where(p => p.CategoryId == CatId || p.Category.ParentCategoryId == CatId).AsQueryable();
            }
            if (!string.IsNullOrWhiteSpace(SearchKey))
            {
                productQuery = productQuery.Where(p => p.Name.Contains(SearchKey) || p.Brand.Contains(SearchKey)).AsQueryable();
            }
            var product = productQuery.ToPaged(Page, 20, out totalRow);
            Random random = new Random();
            return new ResultDto<ResultProductForSiteDto>
            {
                Data = new ResultProductForSiteDto
                {
                    TotalRow = totalRow,
                    Products = product.Select(p => new ProductForSiteDto
                    {
                        Id = p.Id,
                        Star = random.Next(1, 5),
                        ImageSrc = p.ProductImages.FirstOrDefault().Src,
                        Title = p.Name,
                        Price = p.Price,
                    }).ToList()
                },
                IsSuccess = true,
            };

        }
    }
}
