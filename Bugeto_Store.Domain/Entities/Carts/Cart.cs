using Bugeto_Store.Domain.Entities.Common;
using Bugeto_Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Domain.Entities.Cart
{
    public class Cart : BaseEntity
    {
        public virtual User User { get; set; }
        public long? userId { get; set; }
        public Guid BrowserId { get; set; }
        public bool Finished {  get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }

}
