using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;

namespace Bugeto_Store.Application.Services.HomePages.Queries.GetAllSlidersForAdmin
{
    public class GetAllSlidersForAdminService : IGetAllSlidersForAdminService
    {
        private readonly IDatabaseContext _context;
        public GetAllSlidersForAdminService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<AllSlidersDto>> Execute()
            {
            var sliders = _context.Sliders.ToList().Select(p => new AllSlidersDto
            {
                link = p.link,
                src = p.Src,
                Id = p.Id,
            })
            .ToList();
            return new ResultDto<List<AllSlidersDto>>
            {
                Data = sliders,
                IsSuccess = true,
                Message = "",
            };
        }
    }
}
