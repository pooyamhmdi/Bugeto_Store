using Bugeto_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Products.Queries.GetProductForSite
{
    public interface IGetProductForSiteService
    {
        public ResultDto<ResultProductForSiteDto> Execute(string SearchKey,long? CatId,int Page);
    }
}
