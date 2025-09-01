using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;
using Bugeto_Store.Domain.Entities.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Net;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Bugeto_Store.Application.Services.Products.Commands.AddNewProduct
{
    public interface IAddNewProductService
    {

        public ResultDto Execute(RequestAddNewProductDto request);
    }
    public class AddNewProductService : IAddNewProductService
    {
        private readonly IDatabaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddNewProductService(IDatabaseContext context,
            IHostingEnvironment environment
            )
        {
            _context = context;
            _environment = environment;
        }
        public ResultDto Execute(RequestAddNewProductDto request)
        {
            try
             {
                var category = _context.Categories.Find(request.CategoryId);
                Product product = new Product()
                {
                    Brand = request.Brand,
                    Description = request.Description,
                    Name = request.Name,
                    Category = category,
                    Displayed = request.Displayed,
                    Inventory = request.Inventory,
                    Price = request.Price,
                };
                _context.Products.Add(product);
                List<ProductImages> productImages = new List<ProductImages>();
                foreach (var item in request.Images)
                {
                    var uploadedResult = UploadFile(item);
                    productImages.Add(new ProductImages
                    {
                        Product = product,
                        Src = uploadedResult.FileNameAddress,
                    });
                }
                _context.ProductImages.AddRange(productImages);

                List<ProductFeatures> productFeatures = new List<ProductFeatures>();
                {
                    foreach (var item in request.Features)
                    {
                        productFeatures.Add(new ProductFeatures
                        {
                            DisplayName = item.DisplayName,
                            Value = item.Value,
                            Product = product,
                        });
                    }
                }
                _context.ProductsFeatures.AddRange(productFeatures);
                _context.SaveChangesAsync();

                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "انجام شد"
                };
            }
            catch (Exception ex)
            {

                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "خطا رخ داد ",
                };
            }
        }
        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\ProductImages\";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "images", "ProductImages");

                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = folder + fileName,
                    Status = true,
                };
            }
            return null;
        }
    }
}




public class RequestAddNewProductDto
{
    public string Name { get; set; }
    public string Brand { get; set; }

    public string Description { get; set; }
    public int Price { get; set; }
    public int Inventory { get; set; }
    public long CategoryId { get; set; }
    public bool Displayed { get; set; }
    public List<IFormFile> Images { get; set; }
    public List<AddNewProduct_Features> Features { get; set; }


}
public class AddNewProduct_Features
{
    public string DisplayName { get; set; }
    public string Value { get; set; }
}
public class UploadDto
{
    public long Id { get; set; }
    public bool Status { get; set; }
    public string FileNameAddress { get; set; }
}



