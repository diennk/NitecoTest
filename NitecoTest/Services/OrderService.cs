using NitecoTest.Data.Entities;
using NitecoTest.Data.Repsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NitecoTest.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            this.orderRepository = orderRepository;
        }
    }
}
