using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Application.Interfaces.FacadPatterns;
using Bugeto_Store.Application.Services.HomePages.AddNewSlider;
using Bugeto_Store.Application.Services.HomePages.GetAllSlidersForAdmin;
using Bugeto_Store.Application.Services.HomePages.RemoveSlidersForAdmin;
using Bugeto_Store.Application.Services.Products.Commands.AddNewCategory;
using Bugeto_Store.Application.Services.Products.Commands.AddNewProduct;
using Bugeto_Store.Application.Services.Products.Commands.RemoveCategory;
using Bugeto_Store.Application.Services.Products.Commands.RemoveProduct;
using Bugeto_Store.Application.Services.Products.Queries.GetAllCategory;
using Bugeto_Store.Application.Services.Products.Queries.GetCategories;
using Bugeto_Store.Application.Services.Products.Queries.GetProductDetailForAdmin;
using Bugeto_Store.Application.Services.Products.Queries.GetProductDetailForSite;
using Bugeto_Store.Application.Services.Products.Queries.GetProductForAdmin;
using Bugeto_Store.Application.Services.Products.Queries.GetProductForSite;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.HomePages.FacadPattern
{
    public class SlidersFacad : ISlidersFacad
    {
        private readonly IDatabaseContext _context;
        private readonly IHostingEnvironment _environment;
        public SlidersFacad(IDatabaseContext context,
            IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        private IAddNewSliderService _addNewSliderService;
        public IAddNewSliderService AddNewSliderService
        {
            get
            {
                return _addNewSliderService = _addNewSliderService ?? new AddNewSliderService(_environment,_context);
            }
        }
        private IGetAllSlidersForAdminService _getAllSlidersForAdminService;
        public IGetAllSlidersForAdminService GetAllSlidersForAdminService
        {
            get
            {
                return _getAllSlidersForAdminService = _getAllSlidersForAdminService ?? new GetAllSlidersForAdminService(_context);
            }
        }
        private IRemoveSlidersForAdminService _removeSlidersForAdminService;
        public IRemoveSlidersForAdminService RemoveSlidersForAdminService
        {
            get
            {
                return _removeSlidersForAdminService = _removeSlidersForAdminService ?? new RemoveSlidersForAdminService(_context);
            }
        }
    }
}
