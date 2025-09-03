using Bugeto_Store.Application.Services.Common.Queries.GetCategory;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.ViewComponents
{
    public class Search:ViewComponent
    {
        private readonly IGetCategoryService _categoryService;
        public Search(IGetCategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            var category = _categoryService.Execute();
            return View(viewName:"Search", category.Data);
        }
    }
}
