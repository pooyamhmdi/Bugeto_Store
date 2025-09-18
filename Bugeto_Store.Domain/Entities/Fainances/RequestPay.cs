using Bugeto_Store.Domain.Entities.Common;
using Bugeto_Store.Domain.Entities.Orders;
using Bugeto_Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Domain.Entities.Fainances
{
    public class RequestPay : BaseEntity
    {
        public Guid Guid { get; set; }
        public virtual User User { get; set; }
        public long UserId { get; set; }
        public int Amount { get; set; }
        public bool IsPay { get; set; }
        public DateTime? PayDate { get; set; }
        public string? Autority { get; set; }
        public long RefId { get; set; } = 0;
        public ICollection<Order> Orders { get; set; }
    }
}
