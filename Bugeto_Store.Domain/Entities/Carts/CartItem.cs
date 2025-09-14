using Bugeto_Store.Domain.Entities.Common;
using Bugeto_Store.Domain.Entities.Products;

namespace Bugeto_Store.Domain.Entities.Cart
{
    public class CartItem : BaseEntity
    {
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }
        public virtual Cart Cart { get; set; }
        public long CartId { get; set; }    
        public int Count { get; set; }
        public int Price { get; set; }
    }

}
