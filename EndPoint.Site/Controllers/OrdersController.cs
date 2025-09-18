using Bugeto_Store.Application.Interfaces.FacadPatterns;
using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {

        private readonly IOrderFacad _orderFacad;
        public OrdersController(IOrderFacad orderFacad)
        {
            _orderFacad = orderFacad;
        }
        public IActionResult Index(int page = 1, int pageSize = 5)
        {
            var userId= ClaimUtility.GetUserID(User);

            return View(_orderFacad.GetUserOrdersService.Execute(userId.Value,page,pageSize).Data);
        }
    }
}
