using NitecoTestApp.Data.Entities;
using NitecoTestApp.Data.Repsitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NitecoTestApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }
        public List<Product> GetProducts() 
        {
            return productRepository.GetAll().ToList();
        }
    }
}
