using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;

namespace Bugeto_Store.Application.Services.Products.Commands.RemoveCategory
{
    public class RemoveCategoryService : IRemoveCategoryService
    {
        private readonly IDatabaseContext _context;
        public RemoveCategoryService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long categoryId)
        {
            var category  = _context.Categories.Find(categoryId);
            if (category == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "دسته یافت نشد"
                };
            }
            category.RemovedTime = DateTime.Now;
            category.IsRemoved = true;
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "دسته با موفقیت حذف شد"
            };
        }
    }
}
