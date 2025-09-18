using Bugeto_Store.Domain.Entities.Orders;

namespace Bugeto_Store.Application.Services.Orders.Queries.GetOrdersForAdmin
{
    public class OrdersDto
    {
        public DateTime InsertTime { get; set; }
        public long UserId { get; set; }
        public long RequestId { get; set; }
        public long OrderId { get; set; }
        public int ProductCount { get; set; }
        public OrderState OrderState { get; set; }
    }
}
