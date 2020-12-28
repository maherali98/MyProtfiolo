using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Page
{
    public static class Pagaination
    {
        public static PageData<T> PageResult<T>(this List<T> list, int PageNumber, int PageSize) where T : class
        {
            var result = new PageData<T>();
            result.Data = list.Skip(PageSize * (PageNumber - 1)).Take(PageSize).ToList();
            result.Currentpage = PageNumber;
            result.TotalPages = Convert.ToInt32(Math.Ceiling((double)list.Count()/PageSize));
            return result;
        }
    }
}
