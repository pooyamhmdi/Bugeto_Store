using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;

namespace Bugeto_Store.Application.Services.Products.Commands.RemoveProduct
{
    public class RemoveProductService : IRemoveProductService
    {
        private readonly IDatabaseContext _context;
        public RemoveProductService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long ProductId)
        {
            var product = _context.Products.Find(ProductId);
            if (product == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "محصول پیدا نشد"
                };
            }
            product.IsRemoved = true;
            product.RemovedTime = DateTime.Now;
            _context.Products.Remove(product);
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "محصول با موفقیت حذف شد "
            };
        }
    }
}
