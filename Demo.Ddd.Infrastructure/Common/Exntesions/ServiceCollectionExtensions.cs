using Demo.Ddd.Application.Common;
using Demo.Ddd.Application.Common.Data;
using Demo.Ddd.Domain.Customers;
using Demo.Ddd.Domain.Customers.Baskets;
using Demo.Ddd.Domain.Products;
using Demo.Ddd.Infrastructure.Common.Data;
using Demo.Ddd.Infrastructure.Common.DomainEventsDispatching;
using Demo.Ddd.Infrastructure.Domain.Customers;
using Demo.Ddd.Infrastructure.Domain.Customers.Baskets;
using Demo.Ddd.Infrastructure.Domain.Products;
using Demo.Ddd.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using Demo.Ddd.Domain.SharedKernel;

namespace Demo.Ddd.Infrastructure.Common.Exntesions
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

            if (context != null && !context.Database.CanConnect()) //For DB Migration
                return services;

            if (!context.Products.Any())
            {
                var products = new List<Product>()
                {
                    Product.Create("Iphone SE", "MP1", MoneyValue.Of(2000.00M, Currency.TRY), 50, productCounter),
                    Product.Create("Iphone 6", "MP2", MoneyValue.Of(2200.00M, Currency.TRY), 50, productCounter),
                    Product.Create("Iphone 6S", "MP3", MoneyValue.Of(1400.00M, Currency.TRY), 50, productCounter),
                    Product.Create("Iphone 7", "MP4", MoneyValue.Of(1200.00M, Currency.TRY), 50, productCounter),
                    Product.Create("Iphone X", "MP5", MoneyValue.Of(3010.00M, Currency.TRY), 50, productCounter)
                };

                context.Products.AddRange(products);
            }

            context.SaveChanges();

            return services;
        }
    }
}