using Bugeto_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Products.Commands.AddNewCategory
{
    public interface IAddNewCategoryServicecs
    {
        ResultDto Execute(long? ParentId, string Name);
    }
}
