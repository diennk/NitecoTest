using NitecoTestApp.Data.Entities;
using NitecoTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NitecoTestApp.Services
{
    public interface IOrderService
    {
        OrderSearchResult Search(OrderSearchModel orderSearchModel);
        Task CreateAsync(Order order);
    }
}
