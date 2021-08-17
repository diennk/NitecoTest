using Microsoft.EntityFrameworkCore;
using NitecoTestApp.Data.Entities;
using NitecoTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NitecoTestApp.Data.Repsitories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public (List<Order>, int) Search(OrderSearchModel orderSearchModel)
        {
            var query = dbContext.Orders.AsQueryable();
            query = query.Include(x => x.Customer).Include(x=>x.Product).ThenInclude(x=>x.Category);

            if (!string.IsNullOrEmpty(orderSearchModel.CategoryName))
            {
                query = query.Where(x => x.Product.Category.Name.Contains(orderSearchModel.CategoryName));
            }

            if(orderSearchModel.OrderField == "ProductName")
            {
                query = orderSearchModel.OrderDesc == 1 ? query.OrderByDescending(x => x.Product.Name) : query.OrderBy(x => x.Product.Name);
            } 
            else if (orderSearchModel.OrderField == "CategoryName")
            {
                query = orderSearchModel.OrderDesc == 1 ? query.OrderByDescending(x => x.Product.Category.Name) : query.OrderBy(x => x.Product.Category.Name);

            }
            else if (orderSearchModel.OrderField == "CustomerName")
            {
                query = orderSearchModel.OrderDesc == 1 ? query.OrderByDescending(x => x.Customer.Name) : query.OrderBy(x => x.Customer.Name);
            }

            return (query.Skip((orderSearchModel.PageIndex - 1) * orderSearchModel.PageSize).Take(orderSearchModel.PageSize).ToList(), query.Count());
        }
    }
}
