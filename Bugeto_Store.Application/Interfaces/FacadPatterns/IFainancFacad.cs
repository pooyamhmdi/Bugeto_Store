using Bugeto_Store.Application.Services.Fainances.Commands;
using Bugeto_Store.Application.Services.Fainances.Commands.AddRequestPay;
using Bugeto_Store.Application.Services.Fainances.Queries.GetRequestPay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Interfaces.FacadPatterns
{
    public interface IFainancFacad
    {
        IAddRequestPayService AddRequestPayService { get; }
        IGetRequestPayService GetRequestPayService { get; }
    }
}
