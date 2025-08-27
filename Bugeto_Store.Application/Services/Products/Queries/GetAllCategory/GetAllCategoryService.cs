using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Bugeto_Store.Application.Services.Products.Queries.GetAllCategory
{
    public class GetAllCategoryService:IGetAllCategoryService
    {
        private readonly IDatabaseContext _context;
        public GetAllCategoryService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<AllCategoriesDto>> Execute()
        {
            var categories = _context
                .Categories
                .Include(p => p.ParentCategory)
                .Where(p => p.ParentCategoryId != null)
                .ToList()
                .Select(p=> new AllCategoriesDto
                {
                    Id = p.Id,
                    Name = $"{p.ParentCategory?.Name ?? "بدون والد"} - {p.Name}",
                }
                )
                .ToList();
            return new ResultDto<List<AllCategoriesDto>>
            {
                Data = categories,
                IsSuccess = false,
                Message = ""
            };
        }
    }
}
