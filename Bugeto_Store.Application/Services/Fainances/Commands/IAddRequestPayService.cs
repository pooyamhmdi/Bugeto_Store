using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;
using Bugeto_Store.Domain.Entities.Fainances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Fainances.Commands
{
    public interface IAddRequestPayService
    {
        public ResultDto<ResultRequestPayDto> Execute(int Amount, long UserId);
    }
    public class AddRequestPayService : IAddRequestPayService
    {
        private readonly IDatabaseContext _context;
        public AddRequestPayService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRequestPayDto> Execute(int Amount, long UserId)
        {
            var user = _context.Users.Find(UserId);
            RequestPay requestPay = new RequestPay()
            {
                Amount = Amount,
                Guid = Guid.NewGuid(),
                User = user,
                IsPay = false,
            };
            _context.RequestPays.Add(requestPay);
            _context.SaveChanges();
            return new ResultDto<ResultRequestPayDto>
            {
                Data = new ResultRequestPayDto
                {
                    Guid = requestPay.Guid,
                    Amount = requestPay.Amount,
                    Email = user.Email,
                    RequestPayId = requestPay.Id,
                },
                IsSuccess = true,
            };
        }
    }
    public class ResultRequestPayDto
    {
        public Guid Guid { get; set; }
        public int Amount { get; set; }
        public string Email { get; set; }
        public long RequestPayId { get; set; }
    }
}
