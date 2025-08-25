using Bugeto_Store.Application.Services.Users.Commands.EditUser;
using Bugeto_Store.Application.Services.Users.Commands.RegisterUser;
using Bugeto_Store.Application.Services.Users.Commands.RemoveUser;
using Bugeto_Store.Application.Services.Users.Commands.RegisterUser;
using Bugeto_Store.Application.Services.Users.Commands.UserStatusChange;
using Bugeto_Store.Application.Services.Users.Commands.UserStatusChange;
using Bugeto_Store.Application.Services.Users.Queries.GetRoles;
using Bugeto_Store.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IRemoveUserService _removeUserService;
        private readonly IUserStatusChangeService _userSatusChangeService;
        private readonly IEditUsersSevice _editUserService;
        public UsersController(IGetUsersService getUsersService
            , IGetRolesService getRolesService
            , IRegisterUserService registerUserService
            , IRemoveUserService removeUserService
            , IUserStatusChangeService userSatusChangeService
            , IEditUsersSevice editUserService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;
            _removeUserService = removeUserService;
            _userSatusChangeService = userSatusChangeService;
            _editUserService = editUserService;
        }


        public IActionResult Index(string serchkey, int page = 1)
        {
            return View(_getUsersService.Execute(new RequestGetUsersDto
            {
                Page = page,
                SearchKey = serchkey,
            }));
        }





        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "Id", "Name");
            return View();
        }


        [HttpPost]
        public IActionResult Create(string Email, string FullName, long RoleId, string Password, string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = Email,
                FullName = FullName,
                roles = new List<RolesInRegisterUserDto>()
                   {
                        new RolesInRegisterUserDto
                        {
                             Id= RoleId
                        }
                   },
                Password = Password,
                RePassword = RePassword,
            });
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(long UserId)
        {
            return Json(_removeUserService.Execute(UserId));
        }

        public IActionResult UserSatusChange(long UserId)
        {
            return Json(_userSatusChangeService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult Edit(long UserId, string Fullname)
        {
            return Json(_editUserService.Execute(new RequestEditUserDto
            {
                FullName = Fullname,
                UserId = UserId,
            }));
        }

    }
}
