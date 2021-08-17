using NitecoTestApp.Data.Entities;
using NitecoTestApp.Data.Repsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NitecoTestApp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public List<Customer> GetCustomers()
        {
            return customerRepository.GetAll().ToList();
        }
    }
}
