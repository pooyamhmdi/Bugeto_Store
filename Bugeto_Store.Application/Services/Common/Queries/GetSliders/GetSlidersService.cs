using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;

namespace Bugeto_Store.Application.Services.Common.Queries.GetSliders
{
    public class GetSlidersService : IGetSlidersService
    {
        private readonly IDatabaseContext _context;
        public GetSlidersService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<SlidersDto>> Execute()
        {
            var sliders = _context.Sliders.OrderByDescending(p => p.Id)
                .ToList()
                .Select(p=> new SlidersDto()
                {
                    Link = p.link,
                    Src = p.Src,
                }).ToList();
            return new ResultDto<List<SlidersDto>>
            {
                Data = sliders,
                IsSuccess = true
            };
        }
    }
}
