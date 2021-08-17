using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NitecoTestApp.Models
{
    public class OrderSearchModel
    {
        public string CategoryName { get; set; }
        public int PageSize { get;  set; } = 5;
        public int PageIndex { get;  set; } = 1;
        public int Total { get;  set; } = 0;
        public string OrderField { get;  set; } = "ProductName";
        public int OrderDesc { get; set; } = 1;
    }
}
