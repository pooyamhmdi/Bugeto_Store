using Bugeto_Store.Application.Interfaces.FacadPatterns;
using Bugeto_Store.Application.Services.Carts;
using Bugeto_Store.Application.Services.Fainances.Commands.AddRequestPay;
using Bugeto_Store.Application.Services.Fainances.Queries.GetRequestPay;
using Bugeto_Store.Application.Services.Orders.Commands;
using Dto.Payment;
using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Configuration;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;
using Zarinpal.AspNetCore.DTOs;
using Zarinpal.AspNetCore.Extensions;
using Zarinpal.AspNetCore.Interfaces;
using ZarinPal.Class;

namespace EndPoint.Site.Controllers
{
    [Authorize]
    public class PayController : Controller
    {
        private readonly IOrderFacad _orderFacad;
        private readonly IFainancFacad _fainancFacad;
        private readonly ICartService _cartService;
        private readonly CookiesManeger _cookiesManeger;
        private readonly Payment _payment;
        private readonly IZarinpalService _zarinpalService;

        public PayController(
            ICartService cartService,
            IZarinpalService zarinpalService,
            IOrderFacad orderFacad,
            IFainancFacad fainancFacad
             )
        {
            _cartService = cartService;
            _cookiesManeger = new CookiesManeger();
            var expose = new Expose();
            _payment = expose.CreatePayment();
            _zarinpalService = zarinpalService;
            _orderFacad = orderFacad;   
            _fainancFacad = fainancFacad;   
        }


        public async Task<IActionResult> Index()
        {
            long? UserId = ClaimUtility.GetUserID(User);
            var cart = _cartService.GetMyCart(_cookiesManeger.GetBrowserId(HttpContext), UserId);
            int toman = cart.Data.SumAmount;
            int rial = toman.TomanToRial(); // If store your price in toman you can use TomanToRial extension

            /*
             * Pay atttention: Currency is important, default is IRR (Rial)
             *
             * Here we set it to Toman (IRT)
               "Zarinpal": {
                ... 
                "Currency": "IRT", // IRR - IRT
                ...
            }
             */

            var request = new ZarinpalRequestDTO(toman, "خرید",
                "https://localhost:7219/Home/Verify",
                "test@test.com", "09123456789");

            var result = await _zarinpalService.RequestAsync(request);

            if (result.Data != null)
            {
                // You can store or log zarinpal data in database
                string authority = result.Data.Authority;
                int code = result.Data.Code;
                int fee = result.Data.Fee;
                string feeType = result.Data.FeeType;
                string message = result.Data.Message;
            }

            if (result.IsSuccessStatusCode)
            {
                return Redirect(result.RedirectUrl);
            }

            // Check 'Status' and 'Authority' query param so zarinpal sent for us
            if (HttpContext.IsValidZarinpalVerifyQueries())
            {
                var verify = new ZarinpalVerifyDTO(toman,
                    HttpContext.GetZarinpalAuthorityQuery()!);

                var response = await _zarinpalService.VerifyAsync(verify);

                if (response.Data != null)
                {
                    // You can store or log zarinpal data in database
                    ulong refId = response.Data.RefId;
                    int fee = response.Data.Fee;
                    string feeType = response.Data.FeeType;
                    int code = response.Data.Code;
                    string cardHash = response.Data.CardHash;
                    string cardPan = response.Data.CardPan;
                }

                if (response.IsSuccessStatusCode)
                {
                    // Do Somethings...
                    var refId = response.RefId;
                    var statusCode = response.StatusCode;
                }

                return View(response.IsSuccessStatusCode);
            }

            return View(false);
        }



















































        //public async Task<IActionResult> Index()
        //{
        //    long? UserId = ClaimUtility.GetUserID(User);
        //    var cart = _cartService.GetMyCart(_cookiesManeger.GetBrowserId(HttpContext), UserId);
        //    if (cart.Data.SumAmount > 0)
        //    {
        //        var requestPay = _addRequestPayService.Execute(cart.Data.SumAmount, UserId.Value);
        //        // ارسال در گاه پرداخت

        //        var result = await _payment.Request(new DtoRequest()
        //        {
        //            Mobile = "09121112222",
        //            CallbackUrl = $"https://localhost:44339/Pay/Verify?guid={requestPay.Data.Guid}",
        //            Description = "پرداخت فاکتور شماره:" + requestPay.Data.RequestPayId,
        //            Email = requestPay.Data.Email,
        //            Amount = requestPay.Data.Amount,
        //            MerchantId = "xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx",
        //        }, Payment.Mode.sandbox);
        //        return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");


        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Cart");
        //    }

        //}

        //public async Task<IActionResult> Verify(Guid guid, string authority, string status)
        //{

        //    var requestPay = _getRequestPayService.Execute(guid);

        //    var verification = await _payment.Verification(new DtoVerification
        //    {
        //        Amount = requestPay.Data.Amount,
        //        MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
        //        Authority = authority
        //    }, Payment.Mode.sandbox);


        //    //var client = new RestClient("https://www.zarinpal.com/pg/rest/WebGate/PaymentVerification.json");
        //    //client.Timeout = -1;
        //    //var request = new RestRequest(Method.POST);
        //    //request.AddHeader("Content-Type", "application/json");
        //    //request.AddParameter("application/json", $"{{\"MerchantID\" :\"{merchendId}\",\"Authority\":\"{Authority}\",\"Amount\":\"{10000}\"}}", ParameterType.RequestBody);
        //    //IRestResponse response = client.Execute(request);
        //    //VerificationPayResultDto verification = JsonConvert.DeserializeObject<VerificationPayResultDto>(response.Content);
        //    long? UserId = ClaimUtility.GetUserID(User);
        //    var cart = _cartService.GetMyCart(_cookiesManeger.GetBrowserId(HttpContext), UserId);

        //    if (verification.Status == 100)
        //    {
        //        _addNewOrderService.Execute(new RequestAddNewOrderDto
        //        {
        //            CartId = cart.Data.CartId,
        //            UserId = UserId.Value,
        //            RequestPayId = requestPay.Data.Id
        //        });

        //        //redirect to orders
        //        return RedirectToAction("Index", "Orders");
        //    }
        //    else
        //    {

        //    }

        //    return View();
        //}
    }


    public class VerificationPayResultDto
    {
        public int Status { get; set; }
        public long RefID { get; set; }
    }
}
