using Bugeto_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.HomePages.Queries.GetHomePageImagesForAdmin
{
    public interface IGetHomePageImagesForAdminService
    {
        public ResultDto<List<GetHomePageImagesDto>> Execute();
    }

}
