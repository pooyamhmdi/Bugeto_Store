using Bugeto_Store.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Domain.Entities.Products
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public virtual Category ParentCategory { get; set; }
        public long? ParentCategoryId {  get; set; }    
        //برای نمایش زیر دسته های هرگروه
        public ICollection<Category> SubCategories { get; set; }
    }
}
