using Bugeto_Store.Application.Services.HomePages.AddNewSlider;
using Bugeto_Store.Application.Services.HomePages.GetAllSlidersForAdmin;
using Bugeto_Store.Application.Services.HomePages.RemoveSlidersForAdmin;
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
    }
}
