using Bugeto_Store.Domain.Entities.Common;
using Bugeto_Store.Domain.Entities.Products;

namespace Bugeto_Store.Domain.Entities.Orders
{
    public class OrderDetail : BaseEntity
    {
        public virtual Order Order { get; set; }
        public long OrderId { get; set; }
        public Product Product { get; set; }
        public long ProductId { get; set; }
        public int ProductCount { get; set; }
        public int Price { get; set; }

    }
}
