using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Application.Interfaces.FacadPatterns;

using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidersController : Controller
    {
        private readonly ISlidersFacad _slidersFacad;
        public SlidersController(ISlidersFacad slidersFacad)
        {
            _slidersFacad = slidersFacad;
        }
        public IActionResult Index()
        {
            return View(_slidersFacad.GetAllSlidersForAdminService.Execute().Data);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(IFormFile file, string link)
        {
            _slidersFacad.AddNewSliderService.Execute(file, link);
            return View();
        }
        public IActionResult Delete(long Id)
        {
            return Json(_slidersFacad.RemoveSlidersForAdminService.Execute(Id));
        }
    }
}
