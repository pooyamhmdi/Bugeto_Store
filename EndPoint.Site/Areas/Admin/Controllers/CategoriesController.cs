using Bugeto_Store.Application.Interfaces.FacadPatterns;
using Bugeto_Store.Application.Services.Products.Commands.RemoveCategory;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Algorithm;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IProductFacad _productFacad;
        private readonly IRemoveCategoryService _removeCategoryService;
        public CategoriesController(
            IProductFacad productFacad,
            IRemoveCategoryService removeCategoryService
            )
        {
            _productFacad = productFacad;
            _removeCategoryService = removeCategoryService;
        }
        public IActionResult Index(long? parentId)
        {
            return View(_productFacad.GetCategoriesService.Execute(parentId).Data);
        }
        [HttpGet]
        public IActionResult AddNewCategory(long? parentId)
        {
            ViewBag.parentId = parentId;
            return View();
        }
        [HttpPost]
        public IActionResult AddNewCategory(long? parentId, string Name)
        {
            var result = _productFacad.AddNewCategoryService.Execute(parentId, Name);
            return Json(result);
        }
        [HttpPost]
        public IActionResult Delete(long categoryId)
        {
            return Json(_removeCategoryService.Execute(categoryId));
        }
    }
}
