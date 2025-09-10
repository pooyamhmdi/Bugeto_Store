using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;
using Bugeto_Store.Domain.Entities.HomePages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Common.Queries.GetHomePageImages
{
    public interface IGetHomePageImagesService
    {
        public ResultDto<List<HomePageImagesDto>> Execute();
    }
    public class GetHomePageImagesService : IGetHomePageImagesService
    {
        private readonly IDatabaseContext _conetxt;
        public GetHomePageImagesService(IDatabaseContext context)
        {
            _conetxt = context;
        }
        public ResultDto<List<HomePageImagesDto>> Execute()
        {
            var images = _conetxt.HomePageImages.OrderByDescending(p => p.Id).
                Select(p => new HomePageImagesDto
                {
                    Id = p.Id,
                    imageLocation = p.ImageLocation,
                    Link = p.Link,
                    Src = p.Src,
                }).ToList();
            return new ResultDto<List<HomePageImagesDto>>
            {
                Data = images,
                IsSuccess = true
            };
        }
    }

    public class HomePageImagesDto
    {
        public long Id { get; set; }
        public string Src { get; set; }
        public string Link { get; set; }
        public ImageLocation imageLocation { get; set; }
    }
}
