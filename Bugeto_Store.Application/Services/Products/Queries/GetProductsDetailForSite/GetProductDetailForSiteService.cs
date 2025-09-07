using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Bugeto_Store.Application.Services.Products.Queries.GetProductDetailForSite
{
    public class GetProductDetailForSiteService : IGetProductDetailForSiteService
    {
        private readonly IDatabaseContext _context;
        public GetProductDetailForSiteService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<ProductDetailForSiteDto> Execute(long Id)
        {
            var Product = _context.Products
                .Include(p => p.Category)
                .ThenInclude(p => p.ParentCategory)
                .Include(p => p.ProductFeatures)
                .Include(p => p.ProductImages)
                .Where(p => p.Id == Id)
                .FirstOrDefault();
            if (Product == null)
            {
                throw new Exception("Product Not Found");
            }
            Product.ViewCount++;
            _context.SaveChanges();
            return new ResultDto<ProductDetailForSiteDto>
            {
                Data = new ProductDetailForSiteDto
                {
                    Brand = Product.Brand,
                    Category = Product.Category.ParentCategory != null
                        ? $"{Product.Category.ParentCategory.Name} - {Product.Category.Name}"
                        : Product.Category.Name,
                    Description = Product.Description,
                    Id = Product.Id,
                    Price = Product.Price,
                    Title = Product.Name,
                    Images = Product.ProductImages.Select(p => p.Src).ToList(),
                    Features = Product.ProductFeatures.Select(p => new ProductDetailForSite_FeaturesDto
                    {
                        DisplayName = p.DisplayName,
                        Value = p.Value,
                    }).ToList(),

                },
                IsSuccess = true,
                Message = ""
            };
        }



    }
}

