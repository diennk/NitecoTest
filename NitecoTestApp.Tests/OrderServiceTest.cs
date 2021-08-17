using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NitecoTestApp.Services;
using Microsoft.Extensions.Configuration;
using NitecoTestApp.Data;
using NitecoTestApp.Data.Repsitories;

namespace NitecoTestApp.Tests
{
    [TestClass]
    public class OrderServiceTest
    {
        private IOrderService orderService;

        public OrderServiceTest()
        {
            var config = InitConfiguration();

            var services = new ServiceCollection();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(config["ConnectionStrings:DefaultConnection"]));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();

            var serviceProvider = services.BuildServiceProvider();
            orderService = serviceProvider.GetService<IOrderService>();
        }
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }

        [TestMethod]
        public void GetAllOrders()
        {
            var result = orderService.Search(new Models.OrderSearchModel());

            Assert.IsNotNull(result);

            Assert.IsTrue(result.Orders.Count > 0);
        }
    }
}
