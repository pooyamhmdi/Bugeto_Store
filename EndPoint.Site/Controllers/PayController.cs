using Bugeto_Store.Application.Services.Carts;
using Bugeto_Store.Application.Services.Fainances.Commands;
using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace EndPoint.Site.Controllers
{
    [Authorize("Customer")]
    public class PayController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IAddRequestPayService _addRequestPayService;
        private readonly CookiesManeger _cookiesManager;
        public PayController(ICartService cartService,
            IAddRequestPayService addRequestPayService,
            CookiesManeger cookiesManeger)
        {
            _cartService = cartService;
            _addRequestPayService = addRequestPayService;
            _cookiesManager = cookiesManeger;
        }

        public async Task<IActionResult> Index()
        {
            long? userId = ClaimUtility.GetUserID(User);
            var cart = _cartService.GetMyCart(_cookiesManager.GetBrowserId(HttpContext), userId);

            if (cart.Data.SumAmount > 0)
            {
                var requestPay = _addRequestPayService.Execute(cart.Data.SumAmount, userId.Value);
                //ارسال به درگاه پرداخت
            }
            return RedirectToAction("Error" , "Home");
        }
    }
}




