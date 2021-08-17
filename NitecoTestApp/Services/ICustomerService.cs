using NitecoTestApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NitecoTestApp.Services
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();
    }
}
