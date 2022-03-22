using System;
using Demo.Ddd.Domain.SeedWork;

namespace Demo.Ddd.Domain.Products.Events
{
    public class StockAdded : IDomainEvent
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public static StockAdded Create(ProductStock productStock) => new StockAdded
        {
            ProductId = productStock.ProductId,
            Quantity = productStock.Quentity
        };
    }
}