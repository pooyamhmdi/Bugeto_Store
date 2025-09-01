using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Application.Interfaces.FacadPatterns;
using Bugeto_Store.Application.Services.Products.Commands.AddNewCategory;
using Bugeto_Store.Application.Services.Products.Commands.AddNewProduct;
using Bugeto_Store.Application.Services.Products.Commands.RemoveCategory;
using Bugeto_Store.Application.Services.Products.Commands.RemoveProduct;
using Bugeto_Store.Application.Services.Products.Queries.GetAllCategory;
using Bugeto_Store.Application.Services.Products.Queries.GetCategories;
using Bugeto_Store.Application.Services.Products.Queries.GetProductDetailForAdmin;
using Bugeto_Store.Application.Services.Products.Queries.GetProductForAdmin;
using Bugeto_Store.Application.Services.Products.Queries.GetProductForSite;
using Bugeto_Store.Application.Services.Products.Queries.GetProductDetailForSite;
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
                return _addNewProduct = _addNewProduct ?? new AddNewProductService(_context, _environment);
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

        private IGetProductForAdminService _getProductForAdminService;
        public IGetProductForAdminService GetProductForAdminService
        {
            get
            {
                return _getProductForAdminService = _getProductForAdminService ?? new GetProductForAdminService(_context);
            }
        }
        private IRemoveProductService _removeProductService;
        public IRemoveProductService RemoveProductForAdminService
        {
            get
            {
                return _removeProductService = _removeProductService ?? new RemoveProductService(_context);
            }
        }
        private IGetProductDetailForAdminService _getProductDetailForAdminService;
        public IGetProductDetailForAdminService GetProductDetailForAdminService
        {
            get
            {
                return _getProductDetailForAdminService = _getProductDetailForAdminService ?? new GetProductDetailForAdminService(_context);
            }
        }
        private IGetProductForSiteService _getProducForSiteService;

        public IGetProductForSiteService GetProductForSiteService
        {
            get
            {
                return _getProducForSiteService = _getProducForSiteService ?? new GetProductForSiteService(_context);
            }
        }
        private IGetProductDetailForSiteService _getProductDetailForSiteService;

        public IGetProductDetailForSiteService GetProductDetailForSiteService
        {
            get
            {
                return _getProductDetailForSiteService = _getProductDetailForSiteService ?? new GetProductDetailForSiteService(_context);
            }
        }

    }
}
