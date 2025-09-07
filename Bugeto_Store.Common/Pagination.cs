using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Common
{
    public static class Pagination
    {
        public static IEnumerable<TSource> ToPaged<TSource>(this IEnumerable<TSource> source, int page, int pageSize, out int rowsCount)
        {
            rowsCount = source.Count(); // اینجا فقط تعداد آیتم‌های فیلترشده رو می‌شماره
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }


}
