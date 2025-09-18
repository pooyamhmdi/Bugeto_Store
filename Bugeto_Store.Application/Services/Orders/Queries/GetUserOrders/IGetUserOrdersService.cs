using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common;
using Bugeto_Store.Common.Dto;
using Bugeto_Store.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Orders.Queries.GetUserOrders
{
    public interface IGetUserOrdersService
    {
        public ResultDto<List<GetUserOrdersDto>> Execute(long UserId, int page = 1, int pageSize = 20);
    }
    public class GetUserOrdersService : IGetUserOrdersService
    {
        private readonly IDatabaseContext _context;
        public GetUserOrdersService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetUserOrdersDto>> Execute(long UserId, int page = 1, int pageSize = 5)
        {
            int rowCount = 0;
            var order = _context.Orders
                .Include(p => p.OrderDetails)
                .ThenInclude(p => p.Product)
                .Where(p => p.UserId == UserId)
                .OrderByDescending(p => p.Id).ToPaged(page, pageSize, out rowCount)
                .ToList()
                .Select(p => new GetUserOrdersDto
                {
                    OrderId = p.Id,
                    OrderState = p.OrderState,
                    RequestPayId = p.RequestPayId,
                    OrderDetails = p.OrderDetails.Select(o => new OrdersDetailDto
                    {
                        Count = o.ProductCount,
                        OrderDetailId = o.Id,
                        Price = o.Price,
                        ProductId = o.ProductId,
                        ProductName = o.Product.Name,
                    }).ToList()
                }).ToList();
            return new ResultDto<List<GetUserOrdersDto>>
            {
                IsSuccess = true,
                Data = order,
                Message = "سفارش با موفقیت از دیتا بیس خوانده شد"
            };
        }
    }
    public class GetUserOrdersDto
    {
        public long OrderId { get; set; }
        public OrderState OrderState { get; set; }
        public long RequestPayId { get; set; }
        public List<OrdersDetailDto> OrderDetails { get; set; }
    }
    public class OrdersDetailDto
    {
        public long OrderDetailId { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
