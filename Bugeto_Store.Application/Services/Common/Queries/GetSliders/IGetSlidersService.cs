using Bugeto_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Common.Queries.GetSliders
{
    public interface IGetSlidersService
    {
        public ResultDto<List<SlidersDto>> Execute();
    }
}
