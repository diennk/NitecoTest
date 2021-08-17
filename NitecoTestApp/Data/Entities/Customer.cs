using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace NitecoTestApp.Data.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Order> Orders { get; set; }
        public Customer()
        {
            Orders = new List<Order>();
        }
    }
}
