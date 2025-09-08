using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;

namespace Bugeto_Store.Application.Services.HomePages.RemoveSlidersForAdmin
{
    public class RemoveSlidersForAdminService : IRemoveSlidersForAdminService
    {
        private readonly IDatabaseContext _context;
        public RemoveSlidersForAdminService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long Id)
        {
            var slider = _context.Sliders.Find(Id);
            if (slider == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "اسلایدر پیدا نشد"
                };
            }
            slider.RemovedTime = DateTime.Now;
            slider.IsRemoved = true;
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "اسلایدر با موفقیت حذف شد"
            };
        }
    }

}
