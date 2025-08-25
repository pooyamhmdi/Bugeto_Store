using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;

namespace Bugeto_Store.Application.Services.Users.Commands.RemoveUser
{
    public class RemoveUserService : IRemoveUserService
    {
        private readonly IDatabaseContext _context;
        public RemoveUserService(IDatabaseContext context)
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
                    Message = "کاربر یافت نشد "
                };
            }
            user.RemovedTime = DateTime.Now;
            user.IsRemoved = true;    
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "کاربر با موفقیت خذف شد"
            };
        }
    }
}
