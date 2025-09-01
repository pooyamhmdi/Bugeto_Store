using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common;
using Bugeto_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Bugeto_Store.Application.Services.Products.Queries.GetProductForAdmin
{
    public class GetProductForAdminService : IGetProductForAdminService
    {
        private readonly IDatabaseContext _context;
        public GetProductForAdminService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<ProductForAdminDto> Execute(int Page = 1, int PageSize = 20)
        {
            int rowCount = 0;
            var product = _context.Products
                .Include(p => p.Category)
                .ToPaged(Page, PageSize, out rowCount)
                .Select(p => new ProductsForAdminList_Dto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Brand = p.Brand,
                    Discription = p.Description,
                    Displayed = p.Displayed,
                    Inventory = p.Inventory,
                    Price = p.Price,
                    Category = p.Category.Name,
                })
                .ToList();
            return new ResultDto<ProductForAdminDto>
            {
                Data = new ProductForAdminDto
                {
                    PageSize = PageSize,
                    RowCount = rowCount,
                    CurrentPage = Page,
                    Products = product,
                },
                IsSuccess = true,
                Message = "",
            };

        }
    }
}

