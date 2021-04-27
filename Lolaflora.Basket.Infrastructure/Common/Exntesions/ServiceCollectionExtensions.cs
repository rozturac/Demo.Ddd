using Lolaflora.Baskets.Application.Common;
using Lolaflora.Baskets.Application.Common.Data;
using Lolaflora.Baskets.Domain.Customers;
using Lolaflora.Baskets.Domain.Customers.Baskets;
using Lolaflora.Baskets.Domain.Products;
using Lolaflora.Baskets.Infrastructure.Common.Data;
using Lolaflora.Baskets.Infrastructure.Common.DomainEventsDispatching;
using Lolaflora.Baskets.Infrastructure.Domain.Customers;
using Lolaflora.Baskets.Infrastructure.Domain.Customers.Baskets;
using Lolaflora.Baskets.Infrastructure.Domain.Products;
using Lolaflora.Baskets.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace Lolaflora.Baskets.Infrastructure.Common.Exntesions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureDependency(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<BasketContext>(options =>
                    options.UseLazyLoadingProxies().UseInMemoryDatabase("BasketDb"));
            }
            else
            {
                services.AddDbContext<BasketContext>(options =>
                options.UseLazyLoadingProxies(true).UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(BasketContext).Assembly.FullName)));
            }

            services.AddScoped<DbContext, BasketContext>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBasketCounter, BasketCounter>();
            services.AddScoped<IProductCounter, ProductCounter>();
            services.AddScoped<IQueriableRepository, QueriableRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IExecutionContextAccessor, ExecutionContextAccessor>();
            services.AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher>();
            services.AddScoped<IDomainEventsAccessor, DomainEventsAccessor>();

            return services;
        }

        public static IServiceCollection AddSeedData(this IServiceCollection services)
        {
            var context = services.BuildServiceProvider().GetService<BasketContext>();
            var productCounter = services.BuildServiceProvider().GetService<IProductCounter>();

            if (!context.Database.CanConnect()) //For DB Migration
                return services;

            if (!context.Products.Any())
            {
                var products = new List<Product>()
                {
                    Product.Create("Iphone SE", "MP1", 2000.00M, 50, productCounter),
                    Product.Create("Iphone 6", "MP2", 2500.00M, 50, productCounter),
                    Product.Create("Iphone 6S", "MP3", 2800.00M, 50, productCounter),
                    Product.Create("Iphone 7", "MP4", 3500.00M, 50, productCounter),
                    Product.Create("Iphone X", "MP5", 4500.00M, 50, productCounter)
                };

                context.Products.AddRange(products);
            }

            context.SaveChanges();

            return services;
        }
    }
}