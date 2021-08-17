using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NitecoTestApp.Data.Entities
{
    public class Order : BaseEntity
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }

        public Product Product { get; set; }
        public Customer Customer { get; set; }

    }
}
