using Bugeto_Store.Application.Services.HomePages.Queries.GetAllSlidersForAdmin;
using Bugeto_Store.Application.Services.Orders.Commands;
using Bugeto_Store.Application.Services.Orders.Queries.GetOrdersForAdmin;
using Bugeto_Store.Application.Services.Orders.Queries.GetUserOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Interfaces.FacadPatterns
{
    public interface IOrderFacad
    {
        IGetUserOrdersService GetUserOrdersService { get;}
        IAddNewOrderService AddNewOrderService { get;}
        IGetOrdersForAdminService GetOrdersForAdminService { get;}
    }
}
