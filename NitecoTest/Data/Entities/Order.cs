using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NitecoTest.Data.Entities
{
    public class Order : BaseEntity
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
