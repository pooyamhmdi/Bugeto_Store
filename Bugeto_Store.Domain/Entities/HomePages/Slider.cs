using Bugeto_Store.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Domain.Entities.HomePages
{
    public class Slider:BaseEntity
    {
        public string Src { get; set; }
        public string link { get; set; }
    }
}
