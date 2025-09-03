using Bugeto_Store.Application.Interfaces.FacadPatterns;
using Bugeto_Store.Application.Services.Common.Queries.GetMenuItem;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.ViewComponents
{
    public class GetMenu: ViewComponent
    {
        private readonly IGetMenuItemService _menuItemService;
        public GetMenu(IGetMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }
        public IViewComponentResult Invoke()
        {
            var menuItem = _menuItemService.Execute();
            return View(viewName: "GetMenu" ,menuItem.Data);
        }
    }
}
