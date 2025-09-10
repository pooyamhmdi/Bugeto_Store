using Bugeto_Store.Application.Services.Common.Queries.GetSliders;
using Bugeto_Store.Application.Services.HomePages.Commands.AddNewSlider;
using Bugeto_Store.Application.Services.HomePages.Commands.RemoveSlidersForAdmin;
using Bugeto_Store.Application.Services.HomePages.Queries.GetAllSlidersForAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Interfaces.FacadPatterns
{
    public interface ISlidersFacad
    {
        IAddNewSliderService AddNewSliderService { get; }
        IGetAllSlidersForAdminService GetAllSlidersForAdminService { get; }
        IRemoveSlidersForAdminService RemoveSlidersForAdminService { get; }
        IGetSlidersService GetSlidersService { get; }
    }
}
