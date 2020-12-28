using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Page
{
    public class PageData<T> where T: class
    {
        public IEnumerable<T> Data { get; set; }
        public int TotalPages { get; set; }
        public int Currentpage { get; set; }

    }
}
