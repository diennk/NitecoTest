using NitecoTestApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NitecoTestApp.Models
{
    public class OrderViewModel
    {
        public int Id { get; internal set; }
        public int ProductId { get; internal set; }
        public int CustomerId { get; set; }
        public int Amount { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; internal set; }
        public string ProductName { get; internal set; }
        public string CategoryName { get; internal set; }
    }
}
