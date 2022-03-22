using Demo.Ddd.Domain.Baskets;
using Demo.Ddd.Domain.Customers;
using Demo.Ddd.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Ddd.Application.Common.Data
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
