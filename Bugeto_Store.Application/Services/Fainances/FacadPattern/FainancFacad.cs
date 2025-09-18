using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Application.Interfaces.FacadPatterns;
using Bugeto_Store.Application.Services.Fainances.Commands.AddRequestPay;
using Bugeto_Store.Application.Services.Fainances.Queries.GetRequestPay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Fainances.FacadPattern
{
    public class FainancFacad : IFainancFacad
    {
        private readonly IDatabaseContext _context;
        public FainancFacad(IDatabaseContext context)
        {
            _context = context;
        }
        private IAddRequestPayService _addRequestPayService;
        public IAddRequestPayService AddRequestPayService
        {
            get
            {
                return _addRequestPayService = _addRequestPayService ?? new AddRequestPayService(_context);
            }
        }
        private IGetRequestPayService _getRequestPayService;
        public IGetRequestPayService GetRequestPayService
        {
            get
            {
                return _getRequestPayService ?? new GetRequestPayService(_context);
            }
        }
    }
}
