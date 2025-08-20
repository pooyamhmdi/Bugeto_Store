using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;
using Bugeto_Store.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Users.Commands.RegisterUser
{
    public interface IRegisterUserService
    {
        ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request);
    }
    public class RegisterUserServiceL : IRegisterUserService
    {
        private readonly IDatabaseContext _dbContext;
        public RegisterUserServiceL(IDatabaseContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request)
        {
            User user = new User
            {
                Email = request.Email,
                FullName = request.FullName,
            };
            List<UserInRole> userInRoles = new List<UserInRole>();
            foreach (var item in request.roles)
            {
                var roles = _dbContext.Roles.Find(item.Id);
                userInRoles.Add(new UserInRole
                {
                    Id = item.Id,
                    Role = roles,
                    UserId = user.Id,
                });
            }
                user.UserInRoles = userInRoles;
                _dbContext.Users.Add(user);
                _dbContext.Savechanges();
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

        }
    }
    public class RequestRegisterUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<RolesInRegisterUserDto> roles { get; set; }
    }
    public class RolesInRegisterUserDto
    {
        public long Id { get; set; }
    }
    public class ResultRegisterUserDto
    {
        public long Id { get; set; }
    }

