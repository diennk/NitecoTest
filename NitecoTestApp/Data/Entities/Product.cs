using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NitecoTestApp.Data.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category{ get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public List<Order> Orders { get; set; }

    }
}
