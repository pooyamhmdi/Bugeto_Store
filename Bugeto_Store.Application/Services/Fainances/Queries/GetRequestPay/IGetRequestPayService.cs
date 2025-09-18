using Bugeto_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Fainances.Queries.GetRequestPay
{
    public interface IGetRequestPayService
    {
        public ResultDto<RequestPayDto> Execute(Guid guid);
    }
}
