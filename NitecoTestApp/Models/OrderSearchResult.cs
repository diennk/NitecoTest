using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NitecoTestApp.Models
{
    public class OrderSearchResult
    {
        public OrderSearchModel OrderSearchModel { get; set; }
        public List<OrderViewModel> Orders { get; set; }
    }
}
