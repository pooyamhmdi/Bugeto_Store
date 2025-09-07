using Bugeto_Store.Application.Interfaces.FacadPatterns;
using Bugeto_Store.Application.Services.Products.Queries.GetProductForSite;
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
        public IActionResult Index(Ordering ordering,string SearchKey ,int page = 1,long? CatId = null, int pageSize = 20 )
        {
            return View(_productFacad.GetProductForSiteService.Execute(ordering,SearchKey, CatId,page,pageSize).Data);
        }
        public IActionResult Detail(long Id)
        {
            return View(_productFacad.GetProductDetailForSiteService.Execute(Id).Data);
        }

    }
}