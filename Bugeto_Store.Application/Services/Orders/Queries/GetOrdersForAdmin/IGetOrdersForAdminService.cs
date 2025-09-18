using Bugeto_Store.Common.Dto;
using Bugeto_Store.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Orders.Queries.GetOrdersForAdmin
{
    public interface IGetOrdersForAdminService
    {
        public ResultDto<List<OrdersDto>> Execute(OrderState orderState);
    }
}
