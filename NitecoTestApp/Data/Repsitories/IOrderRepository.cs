using NitecoTestApp.Data.Entities;
using NitecoTestApp.Models;
using System.Collections.Generic;

namespace NitecoTestApp.Data.Repsitories
{
    public interface IOrderRepository : IRepository<Order>
    {
        (List<Order>, int) Search(OrderSearchModel orderSearchModel);
    }
}