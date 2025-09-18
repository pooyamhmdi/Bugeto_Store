using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;
using Bugeto_Store.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;

namespace Bugeto_Store.Application.Services.Orders.Queries.GetOrdersForAdmin
{
    public class GetOrdersForAdminService : IGetOrdersForAdminService
    {
        private readonly IDatabaseContext _context;
        public GetOrdersForAdminService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<OrdersDto>> Execute(OrderState orderState)
        {
            var orders = _context.Orders
                .Include(p=> p.OrderDetails)
                .Where(p=>p.OrderState == orderState)
                .OrderByDescending(p=>p.Id)
                .ToList()
                .Select(p=> new OrdersDto
                {
                    OrderState = p.OrderState,
                    InsertTime = p.InsertTime,
                    OrderId = p.Id,
                    ProductCount = p.OrderDetails.Count,
                    RequestId = p.RequestPay.Id,
                    UserId = p.User.Id,
                }).ToList();
            return new ResultDto<List<OrdersDto>>
            {
                Data = orders,
                IsSuccess = true,
                Message = "سفارشات با موفقیت خوانده شد"
            };
        }
    }
}
