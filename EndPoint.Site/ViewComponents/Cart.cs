using Bugeto_Store.Application.Services.Carts;
using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.ViewComponents
{
    public class Cart : ViewComponent
    {
        private readonly ICartService _cartService;
        private readonly CookiesManeger _cookiesManeger;

        public Cart(ICartService cartService, CookiesManeger cookiesManeger)
        {
            _cartService = cartService;
            _cookiesManeger = cookiesManeger;
        }
        public IViewComponentResult Invoke()
        {
            var userId = ClaimUtility.GetUserID(HttpContext.User);
            return View(viewName: "Cart", _cartService.GetMyCart(_cookiesManeger.GetBrowserId(HttpContext), userId).Data);
        }
    }
}
