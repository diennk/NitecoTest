using Microsoft.AspNetCore.Mvc;
using NitecoTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NitecoTest.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
