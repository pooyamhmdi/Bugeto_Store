using Bugeto_Store.Application.Services.Users.Queries.GetRoles;
using Bugeto_Store.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;
        public UsersController(IGetUsersService getUsersService, IGetRolesService getRolesService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService; 
        }
        [Area("Admin")]
        public IActionResult Index(string searchKey,int page = 1)
        {
            return View(_getUsersService.Execute(new RequestGetUsersDto
            {
                SearchKey = searchKey,
                Page = page
            }));
        }
        [Area("Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "Id", "Name").ToList();
            return View();
        }
    }
}
