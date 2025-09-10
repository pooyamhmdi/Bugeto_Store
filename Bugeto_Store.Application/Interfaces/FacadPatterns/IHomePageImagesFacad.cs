using Bugeto_Store.Application.Services.Common.Queries.GetHomePageImages;
using Bugeto_Store.Application.Services.HomePages.Commands.AddHomePageImages;
using Bugeto_Store.Application.Services.HomePages.Commands.RemoveHomePageImages;
using Bugeto_Store.Application.Services.HomePages.Queries.GetHomePageImagesForAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Interfaces.FacadPatterns
{
    public interface IHomePageImagesFacad
    {
        IGetHomePageImagesForAdminService GetHomePageImagesForAdminService { get; }
        IAddHomePageImagesService AddHomePageImagesService { get; }
        IGetHomePageImagesService GetHomePageImagesService { get;}
        IRemoveHomePageImagesService RemoveHomePageImagesService { get; }
    }
}
