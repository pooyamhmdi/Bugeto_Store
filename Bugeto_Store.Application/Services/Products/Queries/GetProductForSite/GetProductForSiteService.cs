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


        public ResultDto<ResultProductForSiteDto> Execute(Ordering ordering, string SearchKey, long? CatId, int Page, int pageSize)
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
            switch (ordering)
            {
                case Ordering.NotOrder:
                    productQuery = productQuery.OrderByDescending(p => p.Id).AsQueryable();
                    break;
                case Ordering.MostVisited:
                    productQuery = productQuery.OrderByDescending(p => p.ViewCount).AsQueryable();
                    break;
                case Ordering.Bestselling:
                    break;
                case Ordering.MostPopular:
                    productQuery = productQuery.OrderByDescending(p => p.Id).AsQueryable();
                    break;
                case Ordering.theNewest:
                    productQuery = productQuery.OrderByDescending(p => p.Id).AsQueryable();
                    break;
                case Ordering.Cheapest:
                    productQuery = productQuery.OrderBy(p => p.Price).AsQueryable();
                    break;
                case Ordering.theMostExpensive:
                    productQuery = productQuery.OrderByDescending(p => p.Price).AsQueryable();
                    break;
                default:
                    break;

            }
            var product = productQuery.ToPaged(Page, pageSize, out totalRow);
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
