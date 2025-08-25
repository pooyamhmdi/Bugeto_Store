using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;
using Bugeto_Store.Domain.Entities.Users;
using Bugeto_Store.Common;
namespace Bugeto_Store.Application.Services.Users.Commands.RegisterUser
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDatabaseContext _dbContext;
        public RegisterUserService(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ResultDto<ResultRegisterUserDto>
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            Id = 0,
                        },
                        IsSuccess = false,
                        Message = "ایمیل را وارد کنید "
                    };
                }
                if (string.IsNullOrWhiteSpace(request.FullName))
                {
                    return new ResultDto<ResultRegisterUserDto>
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            Id = 0,
                        },
                        IsSuccess = false,
                        Message = "نام را وارد کنید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return new ResultDto<ResultRegisterUserDto>
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            Id = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز را وارد کنید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.RePassword))
                {
                    return new ResultDto<ResultRegisterUserDto>
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            Id = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز را وارد کنید"
                    };
                }
                if (request.Password != request.RePassword)
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            Id = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور و تکرار ان برابر نیست "

                    };
                }
                List<UserInRole> userInRoles = new List<UserInRole>();
                var passwordhasher = new PasswordHasher();
                var hashedpassword = passwordhasher.HashPassword(request.Password);
                User user = new User
                {
                    Email = request.Email,
                    FullName = request.FullName,
                    IsActive = true,
                    Pasword = hashedpassword,
                };
                foreach (var item in request.roles)
                {
                    var roles = _dbContext.Roles.Find(item.Id);
                    userInRoles.Add(new UserInRole
                    {
                        Role = roles,
                        UserId = user.Id,
                    });
                }
                user.UserInRoles = userInRoles;
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto
                    {
                        Id = user.Id,
                    },
                    IsSuccess = true,
                    Message = "ثبت نام کاربر با موفقیت انجام شد"
                };

            }
            catch (Exception)
            {
                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto
                    {
                        Id = 0,
                    },
                    IsSuccess = false,
                    Message = "ثبت نام کاربر انجام نشد"
                };
            }


        }

    }
}

