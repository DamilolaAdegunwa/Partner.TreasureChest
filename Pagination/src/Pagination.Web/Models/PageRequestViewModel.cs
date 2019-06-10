using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination.Web.Models
{
    public class PageRequestViewModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
