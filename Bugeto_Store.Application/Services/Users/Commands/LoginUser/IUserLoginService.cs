using Bugeto_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Users.Commands.LoginUser
{
    public interface IUserLoginService
    {
        public ResultDto<ResultUserloginDto> Execute(string Username, string Password);
    }
}

