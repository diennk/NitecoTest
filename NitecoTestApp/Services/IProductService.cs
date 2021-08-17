using NitecoTestApp.Data.Entities;
using System.Collections.Generic;

namespace NitecoTestApp.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}