namespace Bugeto_Store.Application.Services.Products.Queries.GetProductForAdmin
{
    public class ProductForAdminDto
    {
        public int RowCount { get; set; }
        public int CurrentPage { get; set; } 
        public int PageSize { get; set; } = 10;
        public List<ProductsForAdminList_Dto> Products { get; set; }

    }
}

