using Microsoft.AspNetCore.Mvc.Rendering;
using NitecoTestApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NitecoTestApp.Models
{
    public class OrderFormModel
    {
        //[Required]
        //public string OrderName { get; set; }
        [Required(ErrorMessage = "Product is required")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Customer is required")]
        public int CustomerId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Today;
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Amount just in range 1-100")]
        public int Amount { get; set; } = 1;

        public List<SelectListItem> Products { get; set; }
        public List<SelectListItem> Customers { get; set; }
    }
}
