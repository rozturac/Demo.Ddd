using Lolaflora.Baskets.Domain.Baskets;
using Lolaflora.Baskets.Domain.Customers;
using Lolaflora.Baskets.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lolaflora.Baskets.Application.Common.Data
{
    public interface IQueriableRepository
    {
        IQueryable<Customer> Customers { get; }
        IQueryable<Basket> Baskets { get; }
        IQueryable<BasketProduct> BasketProducts { get; }
        IQueryable<Product> Products { get; }
        IQueryable<ProductStock> ProductStocks { get; }
    }
}
