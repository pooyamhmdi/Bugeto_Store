namespace Bugeto_Store.Application.Services.Carts
{
    public class CartItemDto
    {
        public long Id { get; set; }
        public string Product { get; set; }
        public string Images {  get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
