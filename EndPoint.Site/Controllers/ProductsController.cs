using Bugeto_Store.Application.Interfaces.FacadPatterns;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductFacad _productFacad;
        public ProductsController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }
        public IActionResult Index(string SearchKey ,int page,long? CatId = null )
        {
            return View(_productFacad.GetProductForSiteService.Execute(SearchKey, CatId,page).Data);
        }
        public IActionResult Detail(long Id)
        {
            return View(_productFacad.GetProductDetailForSiteService.Execute(Id).Data);
        }

    }
}