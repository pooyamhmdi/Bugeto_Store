using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Application.Interfaces.FacadPatterns;
using Bugeto_Store.Application.Services.HomePages.Queries.GetAllSlidersForAdmin;
using Bugeto_Store.Application.Services.Orders.Commands;
using Bugeto_Store.Application.Services.Orders.Queries.GetOrdersForAdmin;
using Bugeto_Store.Application.Services.Orders.Queries.GetUserOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Orders.FacadPattern
{
    public class OrderFacad : IOrderFacad
    {
        private readonly IDatabaseContext _context;
        public OrderFacad(IDatabaseContext context)
        {
            _context = context;
        }
        private IGetUserOrdersService _userOrdersService;
        public IGetUserOrdersService GetUserOrdersService
        {
            get
            {
                return _userOrdersService = _userOrdersService ?? new GetUserOrdersService(_context);
            }
        }
        private IAddNewOrderService _addNewOrderService;
        public IAddNewOrderService AddNewOrderService
        {
            get
            {
               return _addNewOrderService = _addNewOrderService ?? new AddNewOrderService(_context);
            }
        }
        private IGetOrdersForAdminService _getOrdersForAdminService;
        IGetOrdersForAdminService IOrderFacad.GetOrdersForAdminService
        {
            get
            {
                return _getOrdersForAdminService ?? new GetOrdersForAdminService(_context);
            }
        }

    }
}
