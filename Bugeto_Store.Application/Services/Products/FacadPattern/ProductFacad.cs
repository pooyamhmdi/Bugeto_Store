using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Application.Interfaces.FacadPatterns;
using Bugeto_Store.Application.Services.Products.Commands.AddNewCategory;
using Bugeto_Store.Application.Services.Products.Queries.GetCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Products.FacadPattern
{
    public class ProductFacad : IProductFacad
    {
        private readonly IDatabaseContext _context;
        public ProductFacad(IDatabaseContext context)
        {
            _context = context;
        }
        private AddNewCategoryService _addNewCategory;
        public AddNewCategoryService AddNewCategoryService
        {
            get
            {
                return _addNewCategory = _addNewCategory ?? new AddNewCategoryService(_context);
            }
        }
        private IGetCategoriesService _getCategories;

        public IGetCategoriesService GetCategoriesService
        {
            get
            {
                return _getCategories = _getCategories ?? new GetCategoriesService(_context);
            }
        }
    }
}
