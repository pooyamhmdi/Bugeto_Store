
using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;

namespace Bugeto_Store.Application.Services.Fainances.Queries.GetRequestPay
{
    public class GetRequestPayService : IGetRequestPayService
    {
        private readonly IDatabaseContext _context;
        public GetRequestPayService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<RequestPayDto> Execute(Guid guid)
        {
            var requestPay = _context.RequestPays.Where(p => p.Guid == guid).FirstOrDefault();

            if (requestPay != null)
            {
                return new ResultDto<RequestPayDto>()
                {
                    Data = new RequestPayDto()
                    {
                        Amount = requestPay.Amount,
                        Id = requestPay.Id,
                    }
                };
            }
            else
            {
                throw new Exception("request pay not found");
            }
        }
    }
}
