using System.Collections.Generic;
using Demo.Ddd.Domain.SeedWork;
using Demo.Ddd.Domain.SharedKernel;

namespace Demo.Ddd.Domain.Products.Events
{
    public class ProductCreated : IDomainEvent
    {
        public string Name { get; protected set; }
        public string Code { get; protected set; }
        public MoneyValue UnitPrice { get; protected set; }
        public List<ProductStock> ProductStocks { get; protected set; }

        public static ProductCreated Create(Product product) => new ProductCreated
        {
            Name = product.Name,
            Code = product.Code,
            UnitPrice = product.UnitPrice,
            ProductStocks = product.ProductStocks
        };
    }
}