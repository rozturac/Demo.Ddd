using Demo.Ddd.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using Demo.Ddd.Domain.Products.Events;

namespace Demo.Ddd.Domain.Products
{
    public class ProductStock : Entity<Guid>
    {
        public virtual Product Product { get; protected set; }
        public virtual Guid ProductId { get; protected set; }
        public int Quentity { get; set; }

        private ProductStock(int quantity, Product product)
        {
            Product = product;
            Quentity = quantity;
            
            AddDomainEvent(StockAdded.Create(this));
        }
        
        public static ProductStock Create(int quentity, Product product) => new ProductStock(quentity, product);
    }
}