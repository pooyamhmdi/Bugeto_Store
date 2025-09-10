using Bugeto_Store.Application.Interfaces.FacadPatterns;
using Bugeto_Store.Application.Services.HomePages.Commands.AddHomePageImages;
using Bugeto_Store.Domain.Entities.HomePages;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomePageImagesController : Controller
    {
        private readonly IHomePageImagesFacad _homePageImagesFacad;
        public HomePageImagesController(IHomePageImagesFacad homePageImagesFacad)
        {
            _homePageImagesFacad = homePageImagesFacad;
        }
        public IActionResult Index()
        {
            return View(_homePageImagesFacad.GetHomePageImagesForAdminService.Execute().Data);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(IFormFile file, string link, ImageLocation imageLocation)
        {
            _homePageImagesFacad.AddHomePageImagesService.Execute(new requestAddHomePageImagesDto
            {
                File = file,
                Link = link,
                ImageLocation = imageLocation
            });
            return View();
        }
        [HttpPost]
        public IActionResult Delete(long Id)
        {
            return Json(_homePageImagesFacad.RemoveHomePageImagesService.Execute(Id));
        }
    }
}
