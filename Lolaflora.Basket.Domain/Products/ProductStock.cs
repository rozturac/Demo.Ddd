using Lolaflora.Baskets.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lolaflora.Baskets.Domain.Products
{
    public class ProductStock : Entity<Guid>
    {
        public virtual Product Product { get; protected set; }
        public virtual Guid ProductId { get; protected set; }
        public int Quentity { get; set; }

        protected ProductStock()
        {
            //FOR ORM
        }

        protected ProductStock(int quentity)
        {
            Quentity = quentity;
        }

        protected ProductStock(int quentity, Product product)
        {
            Quentity = quentity;
            Product = product;
        }

        public static ProductStock Create(int quentity) => new ProductStock(quentity);
        public static ProductStock Create(int quentity, Product product) => new ProductStock(quentity, product);
    }
}