using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bugeto_Store.Application.Services.Users.Queries.GetUsers.GetUsersService;

namespace Bugeto_Store.Application.Services.Users.Queries.GetUsers
{
    public interface IGetUsersService
    {
        ResaultGetUsersDto Execute(RequestGetUsersDto request);
    }
}
