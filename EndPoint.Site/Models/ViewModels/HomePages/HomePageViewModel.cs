using Bugeto_Store.Application.Services.Common.Queries.GetHomePageImages;
using Bugeto_Store.Application.Services.Common.Queries.GetSliders;
using Bugeto_Store.Application.Services.Products.Queries.GetProductForSite;

namespace EndPoint.Site.Models.ViewModels.HomePages
{
    public class HomePageViewModel
    {
        public List<SlidersDto> Sliders { get; set; }
        public List<HomePageImagesDto> PageImages { get; set; }
        public List<ProductForSiteDto> Camera { get; set; }
        public List<ProductForSiteDto> Mobile { get; set; }
        public List<ProductForSiteDto> Laptop { get; set; }
    }
}
