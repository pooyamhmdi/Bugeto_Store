using Bugeto_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.HomePages.Commands.RemoveHomePageImages
{
    public interface IRemoveHomePageImagesService
    {
        public ResultDto Execute(long Id);
    }
}
