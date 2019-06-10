using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination.Web.Models
{
    public class PageResultViewModel<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
