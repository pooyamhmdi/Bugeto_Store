using Bugeto_Store.Application.Interfaces.FacadPatterns;
using Bugeto_Store.Application.Services.Common.Queries.GetHomePageImages;
using Bugeto_Store.Application.Services.Common.Queries.GetSliders;
using Bugeto_Store.Application.Services.Products.Queries.GetProductForSite;
using EndPoint.Site.Models;
using EndPoint.Site.Models.ViewModels.HomePages;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EndPoint.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISlidersFacad _sliderFacad;
        private readonly IHomePageImagesFacad _homePageImagesFacad;
        private readonly IProductFacad _productFacad;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
            ISlidersFacad slidersFacad,
            IHomePageImagesFacad homePageImagesFacad,
            IProductFacad productFacad
            )
        {
            _logger = logger;
            _sliderFacad = slidersFacad;
            _homePageImagesFacad = homePageImagesFacad;
            _productFacad = productFacad;
        }

        public IActionResult Index()
        {
            HomePageViewModel homePage = new HomePageViewModel()
            {
                Sliders = _sliderFacad.GetSlidersService.Execute().Data,
                PageImages = _homePageImagesFacad.GetHomePageImagesService.Execute().Data,
                Camera = _productFacad.GetProductForSiteService.Execute(Ordering.theNewest,null,10009,1,6).Data.Products,
            };
            return View(homePage);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
