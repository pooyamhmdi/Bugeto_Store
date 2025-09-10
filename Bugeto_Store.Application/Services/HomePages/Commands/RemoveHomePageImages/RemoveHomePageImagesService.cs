using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;

namespace Bugeto_Store.Application.Services.HomePages.Commands.RemoveHomePageImages
{
    public class RemoveHomePageImagesService : IRemoveHomePageImagesService
    {
        private readonly IDatabaseContext _context;
        public RemoveHomePageImagesService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long Id)
        {

            var image = _context.HomePageImages.Find(Id);
            if (image == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "تصویر پیدا نشد"
                };
            }
            image.IsRemoved = true;
            image.RemovedTime = DateTime.Now;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "تصویر یا موفقیت حذف شد"
            };
        }
    }
}
