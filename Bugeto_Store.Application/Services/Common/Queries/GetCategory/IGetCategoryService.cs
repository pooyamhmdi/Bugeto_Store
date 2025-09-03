﻿using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Services.Common.Queries.GetCategory
{
    public interface IGetCategoryService
    {
        public ResultDto<List<CategoryDto>> Execute();
    }
    public class CategoryDto
    {
        public long CatId { get; set; }
        public string CategoryName { get; set; }
    }
    public class GetCategoryService : IGetCategoryService
    {
        private readonly IDatabaseContext _context;
        public GetCategoryService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<CategoryDto>> Execute()
        {
            var category = _context.Categories.Where(p => p.ParentCategoryId == null)
                .ToList()
                .Select(p => new CategoryDto { CatId = p.Id, CategoryName = p.Name }).ToList();
            return new ResultDto<List<CategoryDto>>()
            {
                Data = category,
                IsSuccess = true,
                Message = "",
            };

        }
    }
}
