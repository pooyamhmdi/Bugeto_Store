using Bugeto_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bugeto_Store.Application.Services.Users.Commands.EditUser.EditUsersSevice;

namespace Bugeto_Store.Application.Services.Users.Commands.EditUser
{
    public interface IEditUsersSevice
    {
        public ResultDto Execute(RequestEditUserDto request);
    }
}
