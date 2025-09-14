using Bugeto_Store.Application.Services.Carts;
using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        CookiesManeger _cookiesManeger;
        public CartController(ICartService cartService, CookiesManeger cookiesManeger)
        {
            _cartService = cartService;
            _cookiesManeger = cookiesManeger;
        }
        public IActionResult Index()
        {
            var userId = ClaimUtility.GetUserID(User);
            var resultGetLst = _cartService.GetMyCart(_cookiesManeger.GetBrowserId(HttpContext), userId);
            return View(resultGetLst.Data);
        }
        public IActionResult AddToCart(long ProductId)
        {
            var resultAdd = _cartService.AddToCart(ProductId, _cookiesManeger.GetBrowserId(HttpContext));
            return RedirectToAction("Index");
        }
        public IActionResult Add(long CartItemId)
        {
            _cartService.Add(CartItemId);
            return RedirectToAction("Index");
        }
        public IActionResult LowOff(long CartItemId)
        {
            _cartService.LowOff(CartItemId);
            return RedirectToAction("Index");
        }
        public IActionResult Remove(long ProductId)
        {
            _cartService.RemoveFromCart(ProductId, _cookiesManeger.GetBrowserId(HttpContext));
            return RedirectToAction("Index");

        }
    }
}
