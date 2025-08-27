using Bugeto_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Products.Queries.GetAllCategory
{
    public interface IGetAllCategoryService
    {
        public ResultDto<List<AllCategoriesDto>> Execute();
    }
}
