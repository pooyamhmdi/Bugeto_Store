using Bugeto_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Common.Queries.GetMenuItem
{
    public interface IGetMenuItemService
    {
        public ResultDto<List<MenuItemDto>> Execute();
    }
}

