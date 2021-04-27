using Lolaflora.Baskets.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lolaflora.Baskets.Domain.Products
{
    public class ProductPriceData : ValueObject
    {
        public virtual Guid ProductId { get; protected set; }
        public decimal Price { get; protected set; }

        internal ProductPriceData(Guid productId, decimal price)
        {
            ProductId = productId;
            Price = price;
        }

        internal static ProductPriceData Create(Guid productId, decimal price) => new ProductPriceData(productId, price);
    }
}
