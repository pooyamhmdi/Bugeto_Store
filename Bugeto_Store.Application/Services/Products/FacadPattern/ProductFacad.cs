using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Application.Interfaces.FacadPatterns;
using Bugeto_Store.Application.Services.Products.Commands.AddNewCategory;
using Bugeto_Store.Application.Services.Products.Commands.AddNewProduct;
using Bugeto_Store.Application.Services.Products.Commands.RemoveCategory;
using Bugeto_Store.Application.Services.Products.Queries.GetAllCategory;
using Bugeto_Store.Application.Services.Products.Queries.GetCategories;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IHostingEnvironment _environment;
        public ProductFacad(IDatabaseContext context,
            IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
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
        private IRemoveCategoryService _removeCategory;
        public IRemoveCategoryService RemoveCategoryService
        {
            get
            {
                return _removeCategory = _removeCategory ?? new RemoveCategoryService(_context);
            }
        }
        private AddNewProductService _addNewProduct;

        public AddNewProductService addNewProductService
        {
            get
            {
                return _addNewProduct = _addNewProduct ?? new AddNewProductService(_context,_environment);
            }
        }
        private IGetAllCategoryService _getAllCategories;

        public IGetAllCategoryService GetAllCategoryService
        {
            get
            {
                return _getAllCategories = _getAllCategories ?? new GetAllCategoryService(_context);
            }
        }

    }
}
