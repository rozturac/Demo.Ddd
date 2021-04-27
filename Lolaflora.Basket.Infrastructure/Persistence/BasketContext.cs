using Lolaflora.Baskets.Domain.Baskets;
using Lolaflora.Baskets.Domain.Customers;
using Lolaflora.Baskets.Domain.Products;
using Lolaflora.Baskets.Infrastructure.Common.Exntesions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Lolaflora.Baskets.Infrastructure.Persistence
{
    public class BasketContext : DbContext
    {
        public BasketContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketProduct> BasketProducts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                Console.WriteLine(item.State);
            }
            return base.SaveChanges();
        }
    }
}