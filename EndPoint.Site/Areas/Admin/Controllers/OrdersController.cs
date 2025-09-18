using Bugeto_Store.Application.Interfaces.FacadPatterns;
using Bugeto_Store.Domain.Entities.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrdersController : Controller
    {
        private readonly IOrderFacad _orderFacad;
        public OrdersController(IOrderFacad orderFacad)
        {
            _orderFacad = orderFacad;
        }
        public IActionResult Index(OrderState orderState)
        {
            return View(_orderFacad.GetOrdersForAdminService.Execute(orderState).Data);
        }
    }
}
