using Bugeto_Store.Application.Services.Products.Commands.AddNewCategory;
using Bugeto_Store.Application.Services.Products.Commands.AddNewProduct;
using Bugeto_Store.Application.Services.Products.Commands.RemoveCategory;
using Bugeto_Store.Application.Services.Products.Commands.RemoveProduct;
using Bugeto_Store.Application.Services.Products.Queries.GetAllCategory;
using Bugeto_Store.Application.Services.Products.Queries.GetCategories;
using Bugeto_Store.Application.Services.Products.Queries.GetProductDetailForAdmin;
using Bugeto_Store.Application.Services.Products.Queries.GetProductForAdmin;
using Bugeto_Store.Application.Services.Products.Queries.GetProductForSite;
using Bugeto_Store.Application.Services.Products.Queries.GetProductDetailForSite;
using Bugeto_Store.Application.Services.Users.Queries.GetRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Interfaces.FacadPatterns
{
    public interface IProductFacad
    {
        AddNewCategoryService AddNewCategoryService { get; }
        IGetCategoriesService GetCategoriesService { get; }
        IRemoveCategoryService RemoveCategoryService { get; }
        AddNewProductService addNewProductService { get; }
        IGetAllCategoryService GetAllCategoryService { get; }
        //summary
        //دریافت لیست محصولات برای پنل ادمین
        //summary
        IGetProductForAdminService GetProductForAdminService { get; }

        //دیلیت کردن محصول
        IRemoveProductService RemoveProductForAdminService { get; }
        //نشون دادن دیتیله پروداکت برای ادمین
        IGetProductDetailForAdminService GetProductDetailForAdminService { get; }   
        //نشون دادن محصولات در سایت 
        IGetProductForSiteService GetProductForSiteService { get; }
        IGetProductDetailForSiteService GetProductDetailForSiteService { get; }
    }
}
