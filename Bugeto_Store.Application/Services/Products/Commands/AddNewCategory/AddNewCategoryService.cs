using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;
using Bugeto_Store.Domain.Entities.Products;

namespace Bugeto_Store.Application.Services.Products.Commands.AddNewCategory
{
    public class AddNewCategoryService : IAddNewCategoryServicecs
    {
        private readonly IDatabaseContext _context;
        public AddNewCategoryService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long? ParentId, string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "نام دسته بندی را وارد نمایید",
                };
            }
            Category category = new Category()
            {
                Name = Name,
                ParentCategory = GetParent(ParentId),
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقیت اضافه شد"
            };


        }
        private Category GetParent(long? ParentId)
        {
            return _context.Categories.Find(ParentId);
        }
    }
}
