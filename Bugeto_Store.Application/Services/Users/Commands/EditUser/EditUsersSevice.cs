using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;

namespace Bugeto_Store.Application.Services.Users.Commands.EditUser
{
    public class EditUsersSevice : IEditUsersSevice
    {
        private readonly IDatabaseContext _context;
        public EditUsersSevice(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestEditUserDto request)
        {
            var user = _context.Users.Find(request.UserId);
            if (user == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "کاربر یافتت نشد"
                };
            }
            user.FullName = request.FullName;
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "کاربر با موفقیت ویرایش شد "
            };
        }
    }
}
