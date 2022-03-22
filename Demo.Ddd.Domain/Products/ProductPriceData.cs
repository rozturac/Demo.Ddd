using Demo.Ddd.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using Demo.Ddd.Domain.SharedKernel;

namespace Demo.Ddd.Domain.Products
{
    public class ProductPriceData : ValueObject
    {
        public virtual Guid ProductId { get; protected set; }
        public MoneyValue Price { get; protected set; }

        internal ProductPriceData(Guid productId, MoneyValue price)
        {
            ProductId = productId;
            Price = price;
        }

        internal static ProductPriceData Create(Guid productId, MoneyValue price) => new ProductPriceData(productId, price); 
    }
}
