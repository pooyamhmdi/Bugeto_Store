using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common;
using Bugeto_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Products.Queries.GetProductForSite
{
    public interface IGetProductForSiteService
    {
        public ResultDto<ResultProductForSiteDto> Execute(int Page);
    }
    public class GetProductForSiteService : IGetProductForSiteService
    {
        private readonly IDatabaseContext _context;
        public GetProductForSiteService(IDatabaseContext context)
        {
            _context = context;
        }


        public ResultDto<ResultProductForSiteDto> Execute(int Page)
        {
            int totalRow = 0;
            var products = _context.Products
                .Include(p => p.ProductImages)
                .ToPaged(Page, 20, out totalRow);
            Random random = new Random();
            return new ResultDto<ResultProductForSiteDto>
            {
                Data = new ResultProductForSiteDto
                {
                    TotalRow = totalRow,
                    Products = products.Select(p => new ProductForSiteDto
                    {
                        Id = p.Id,
                        Star = random.Next(1, 5),
                        ImageSrc = p.ProductImages.FirstOrDefault().Src,
                        Title = p.Name,
                        Price = p.Price,
                    }).ToList()
                },
                IsSuccess = true,
            };

        }
    }
    public class ResultProductForSiteDto
    {
        public List<ProductForSiteDto> Products { get; set; }
        public int TotalRow { get; set; }
    }
    public class ProductForSiteDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ImageSrc { get; set; }
        public int Star { get; set; }
        public int Price { get; set; }
    }
}
