using NitecoTestApp.Data.Entities;
using NitecoTestApp.Data.Repsitories;
using NitecoTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NitecoTestApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IRepository<Product> productRepository;

        public OrderService(IOrderRepository orderRepository, IRepository<Product> productRepository)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
        }


        public OrderSearchResult Search(OrderSearchModel orderSearchModel)
        {
            var (orders, total) = orderRepository.Search(orderSearchModel);
            orderSearchModel.Total = total;
            var result = new OrderSearchResult
            {
                OrderSearchModel = orderSearchModel,
                Orders = MapToModelList(orders)
            };
            return result;
        }
        public async Task CreateAsync(Order order)
        {
            // check quantity
            var product = await productRepository.GetById(order.ProductId);
            if (product.Quantity < order.Amount) throw new Exception("Product count in inventory not enough");

            var entity = orderRepository.Create(order);
            if(entity != null)
            {
                product.Quantity -= order.Amount;
                await productRepository.Update(product.Id, product);
            }
        }

        private OrderViewModel MapToModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                ProductId = order.ProductId,
                CustomerId = order.CustomerId,
                CustomerName = order.Customer.Name,
                ProductName = order.Product.Name,
                CategoryName = order.Product.Category.Name,
                OrderDate = order.OrderDate,
                Amount = order.Amount
            };
        }

        private List<OrderViewModel> MapToModelList(List<Order> orders)
        {
            var models = from x in orders
                         select MapToModel(x);

            return models.ToList();
        }
    }
}
