using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;

namespace Bugeto_Store.Application.Services.HomePages.Queries.GetHomePageImagesForAdmin
{
    public class GetHomePageImagesForAdminService : IGetHomePageImagesForAdminService
    {
        private readonly IDatabaseContext _conetext;
        public GetHomePageImagesForAdminService(IDatabaseContext context)
        {
            _conetext = context;
        }
        public ResultDto<List<GetHomePageImagesDto>> Execute()
        {
            var images = _conetext.HomePageImages.ToList().Select(p=> new GetHomePageImagesDto
            {
                ImageLocationInSite = p.ImageLocation,
                Link = p.Link,
                Src = p.Src,
                Id = p.Id,
            }).ToList();
            return new ResultDto<List<GetHomePageImagesDto>>()
            {
                Data = images,
                IsSuccess = true
            };
        }
    }

}
