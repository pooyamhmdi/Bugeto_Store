using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;
using Bugeto_Store.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Bugeto_Store.Application.Services.Products.Queries.GetProductDetailForAdmin
{
    public class GetProductDetailForAdminService : IGetProductDetailForAdminService
    {
        private readonly IDatabaseContext _context;
        public GetProductDetailForAdminService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<ProductDetailForAdminDto> Execute(long Id)
        {
            var product = _context.Products
           .Include(p => p.Category)
           .ThenInclude(p => p.ParentCategory)
           .Include(p => p.ProductFeatures)
           .Include(p => p.ProductImages)
           .Where(p => p.Id == Id)
           .FirstOrDefault();
            return new ResultDto<ProductDetailForAdminDto>()
            {
                Data = new ProductDetailForAdminDto()
                {
                    Brand = product.Brand,
                    Category = GetCategory(product.Category),
                    Description = product.Description,
                    Displayed = product.Displayed,
                    Id = product.Id,
                    Inventory = product.Inventory,
                    Name = product.Name,
                    Price = product.Price,
                    Features = product.ProductFeatures.ToList().Select(p => new ProductDetailFeatureDto
                    {
                        Id = p.Id,
                        DisplayName = p.DisplayName,
                        Value = p.Value
                    }).ToList(),
                    Images = product.ProductImages.ToList().Select(p => new ProductDetailImagesDto
                    {
                        Id = p.Id,
                        Src = p.Src,
                    }).ToList(),
                },
                IsSuccess = true,
                Message = "",
            };
        }
        private string GetCategory(Category category)
        {
            string result = category.ParentCategory != null ? $"{category.ParentCategory.Name} - " : "";
            return result += category.Name;
        }   
    }
}
