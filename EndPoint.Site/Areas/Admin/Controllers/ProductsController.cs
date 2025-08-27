using Bugeto_Store.Application.Interfaces.FacadPatterns;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductFacad _productFacad;
        public ProductsController(IProductFacad productFacad)
        {
           _productFacad = productFacad;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddNewProduct()
        {
            ViewBag.Categories = new SelectList(_productFacad.GetAllCategoryService.Execute().Data,"Id","Name");
            return View();
        }
        [HttpPost]
        public IActionResult AddNewProduct(RequestAddNewProductDto request , List<AddNewProduct_Features> features)
        {
            List<IFormFile> images = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                images.Add(file);
            }
            request.Images = images;
            request.Features = features;
            return Json(_productFacad.addNewProductService.Execute(request));
        }
    }
}
