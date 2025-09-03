using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace Bugeto_Store.Application.Services.Common.Queries.GetMenuItem
{
    public class GetMenuItemService : IGetMenuItemService
    {
        private readonly IDatabaseContext _context;
        public GetMenuItemService(IDatabaseContext context)
        {
            _context = context; 
        }
        public ResultDto<List<MenuItemDto>> Execute()
        {
            var category = _context.Categories
                .Include(p => p.SubCategories)
                .Where(p=> p.ParentCategoryId == null)
                .ToList()
                .Select(p => new MenuItemDto
                {
                    CatId = p.Id,
                    Name = p.Name,
                    Child = p.SubCategories.ToList().Select(child => new MenuItemDto
                    {
                        Name = child.Name,
                        CatId = child.Id,
                    }).ToList(),
                }).ToList();
            return new ResultDto<List<MenuItemDto>>()
            {
                Data = category,
                IsSuccess = true
            };
        }
    }
}

