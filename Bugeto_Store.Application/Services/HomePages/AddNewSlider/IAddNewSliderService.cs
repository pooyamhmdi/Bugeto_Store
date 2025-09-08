using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;
using Bugeto_Store.Domain.Entities.HomePages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Bugeto_Store.Application.Services.HomePages.AddNewSlider
{
    public interface IAddNewSliderService
    {
        public ResultDto Execute(IFormFile file, string Link);
    }
    public class AddNewSliderService : IAddNewSliderService
    {
        private readonly IHostingEnvironment _environment;
        private readonly IDatabaseContext _context;
        public AddNewSliderService(IHostingEnvironment environment, IDatabaseContext context)
        {
            _environment = environment;
            _context = context;
        }
        public ResultDto Execute(IFormFile file, string Link)
        {
            var resultUpload = UploadFile(file);
            Slider slider = new Slider()
            {
                link = Link,
                Src = resultUpload.FileNameAddress,
            };
            _context.Sliders.Add(slider);
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
                string folder = Path.Combine("images", "HomePages", "Slider");
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

}
