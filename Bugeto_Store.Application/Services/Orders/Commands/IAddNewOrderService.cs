using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;
using Bugeto_Store.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Orders.Commands
{
    public interface IAddNewOrderService
    {
        public ResultDto Execute(RequestAddNewOrderDto request);
    }
    public class AddNewOrderService : IAddNewOrderService
    {
        private readonly IDatabaseContext _conetxt;
        public AddNewOrderService(IDatabaseContext context)
        {
            _conetxt = context;
        }

        public ResultDto Execute(RequestAddNewOrderDto request)
        {
            var user = _conetxt.Users.Find(request.UserId);
            var cart = _conetxt.Carts.Include(p => p.CartItems).ThenInclude(p => p.Product).Where(p => p.Id == request.CartId).FirstOrDefault();
            var requestPay = _conetxt.RequestPays.Find(request.RequestPayId);
            requestPay.IsPay = true;
            requestPay.PayDate = DateTime.Now;
            cart.Finished = true;
            Order order = new Order()
            {
                Address = "",
                OrderState = OrderState.Processing,
                User = user,
                RequestPay = requestPay,
            };
            _conetxt.Orders.Add(order);
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var item in cart.CartItems)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    Order = order,
                    Product = item.Product,
                    Price = item.Product.Price,
                    ProductCount = item.Count,
                };
                orderDetails.Add(orderDetail);
            }
            _conetxt.OrderDetails.AddRange(orderDetails);
            _conetxt.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = ""
            };
        }
    }
    public class RequestAddNewOrderDto
    {
        public long CartId { get; set; }
        public long RequestPayId { get; set; }
        public long UserId { get; set; }
    }
}
