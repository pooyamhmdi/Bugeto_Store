using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;
using Bugeto_Store.Domain.Entities.HomePages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.HomePages.Commands.AddHomePageImages
{
    public interface IAddHomePageImagesService
    {
        public ResultDto Execute(requestAddHomePageImagesDto request);
    }
    public class AddHomePageImagesService : IAddHomePageImagesService
    {
        private readonly IDatabaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddHomePageImagesService(IDatabaseContext context,
            IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public ResultDto Execute(requestAddHomePageImagesDto request)
        {
            var resultUpload = UploadFile(request.File);
            HomePageImages homePageImages = new HomePageImages()
            {
                Link = request.Link,
                ImageLocation = request.ImageLocation,
                Src = resultUpload.FileNameAddress,
            };
            _context.HomePageImages.Add(homePageImages);
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
            };
        }
        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string folder = Path.Combine("images", "HomePages", "HomepageImages");
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);

                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }

                string extension = Path.GetExtension(file.FileName);
                string fileName = DateTime.Now.Ticks.ToString() + extension;
                var filePath = Path.Combine(uploadsRootFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = Path.Combine(folder, fileName).Replace("\\", "/"),
                    Status = true,
                };
            }

            return new UploadDto()
            {
                Status = false,
                FileNameAddress = "",
            };
        }
    }
    public class requestAddHomePageImagesDto
    {
        public string Link { get; set; }
        public IFormFile File { get; set; }
        public ImageLocation ImageLocation { get; set; }
    }

}
