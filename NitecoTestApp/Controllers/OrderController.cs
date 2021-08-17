using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using NitecoTestApp.Data.Entities;
using NitecoTestApp.Models;
using NitecoTestApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NitecoTestApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly ICustomerService customerService;
        private readonly IProductService productService;
        private readonly ILogger<OrderController> logger;

        public OrderController(IOrderService orderService, ICustomerService customerService, IProductService productService, ILogger<OrderController> logger)
        {
            this.orderService = orderService;
            this.customerService = customerService;
            this.productService = productService;
            this.logger = logger;
        }
        public IActionResult Index([FromQuery] OrderSearchModel orderSearchModel)
        {
            var model = orderSearchModel ?? new OrderSearchModel();
            var orders = orderService.Search(model);
            return View(orders);
        }

        public IActionResult Create()
        {
            var model = PrepairFormModel(new OrderFormModel());

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(OrderFormModel orderFormModel)
        {
            if (!ModelState.IsValid)
            {
                orderFormModel = PrepairFormModel(orderFormModel);
                return View(orderFormModel);
            }

            try
            {
                await orderService.CreateAsync(new Order
                {
                    CustomerId = orderFormModel.CustomerId,
                    ProductId = orderFormModel.ProductId,
                    Amount = orderFormModel.Amount,
                    OrderDate = orderFormModel.OrderDate
                });
            }
            catch (Exception e)
            {
                logger.LogInformation(e.Message);
                ViewBag.Error = e.Message;
                orderFormModel = PrepairFormModel(orderFormModel);
                return View(orderFormModel);
            }

            return Redirect("Index");
        }

        private OrderFormModel PrepairFormModel(OrderFormModel model)
        {
            var customers = customerService.GetCustomers();
            model.Customers = (from x in customers
                               select new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

            var products = productService.GetProducts();
            model.Products = (from x in products
                              select new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

            return model;
        }
    }
}
