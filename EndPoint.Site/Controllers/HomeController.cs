using Bugeto_Store.Application.Services.Common.Queries.GetSliders;
using EndPoint.Site.Models;
using EndPoint.Site.Models.ViewModels.HomePages;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EndPoint.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetSlidersService _getSlidersService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
            IGetSlidersService getSlidersService)
        {
            _logger = logger;
            _getSlidersService = getSlidersService;
        }

        public IActionResult Index()
        {
            HomePageViewModel homePage = new HomePageViewModel()
            {
                Sliders = _getSlidersService.Execute().Data,
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
