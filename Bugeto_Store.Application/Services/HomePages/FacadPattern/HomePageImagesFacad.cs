using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Application.Interfaces.FacadPatterns;
using Bugeto_Store.Application.Services.Common.Queries.GetHomePageImages;
using Bugeto_Store.Application.Services.HomePages.Commands.AddHomePageImages;
using Bugeto_Store.Application.Services.HomePages.Commands.RemoveHomePageImages;
using Bugeto_Store.Application.Services.HomePages.Queries.GetHomePageImagesForAdmin;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.HomePages.FacadPattern
{
    public class HomePageImagesFacad : IHomePageImagesFacad
    {
        private readonly IDatabaseContext _context;
        private readonly IHostingEnvironment _environment;

        public HomePageImagesFacad(IDatabaseContext context,
            IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        private IGetHomePageImagesForAdminService _getHomePageImagesForAdminService;
        public IGetHomePageImagesForAdminService GetHomePageImagesForAdminService
        {
            get
            {
                return _getHomePageImagesForAdminService = _getHomePageImagesForAdminService ?? new GetHomePageImagesForAdminService(_context);
            }
        }
        private IAddHomePageImagesService _addHomePageImagesService;
        public IAddHomePageImagesService AddHomePageImagesService
        {
            get
            {
                return _addHomePageImagesService = _addHomePageImagesService ?? new AddHomePageImagesService(_context, _environment);
            }
        }
        private IGetHomePageImagesService _getHomePageImagesService;
        public IGetHomePageImagesService GetHomePageImagesService
        {
            get
            {
                return _getHomePageImagesService = _getHomePageImagesService ?? new GetHomePageImagesService(_context);
            }
        }
        private IRemoveHomePageImagesService _removeHomePageImagesService;
        public IRemoveHomePageImagesService RemoveHomePageImagesService
        {
            get
            {
                return _removeHomePageImagesService = _removeHomePageImagesService ?? new RemoveHomePageImagesService(_context);
            }
        }
    }
}
