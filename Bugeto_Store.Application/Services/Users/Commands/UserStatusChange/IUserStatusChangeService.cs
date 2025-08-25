
using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;

namespace Bugeto_Store.Application.Services.Users.Commands.UserStatusChange
{
    public interface IUserStatusChangeService
    {
        public ResultDto Execute(long Id);
    }
    public class UserStatuChangeService : IUserStatusChangeService
    {
        private readonly IDatabaseContext _context;
        public UserStatuChangeService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long UserId)
        {
            var user = _context.Users.Find(UserId);
            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }
            user.IsActive = !user.IsActive;
            _context.SaveChanges();
            string userstate = user.IsActive == true ? "فعال" : "غیر فعال";
            return new ResultDto
            {
                IsSuccess = true,
                Message = $"کاربر با موفقیت {userstate} شد"
            };
        }
    }
}
