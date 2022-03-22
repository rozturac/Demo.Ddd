using Demo.Ddd.Application.Common.Data;
using Demo.Ddd.Domain.Baskets;
using Demo.Ddd.Domain.Customers;
using Demo.Ddd.Domain.Products;
using Demo.Ddd.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Ddd.Infrastructure.Common.Data
{
    public class QueriableRepository : IQueriableRepository
    {
        private readonly BasketContext _dbcontext;

        public QueriableRepository(BasketContext context)
        {
            this._dbcontext = context;
        }

        public IQueryable<Customer> Customers => _dbcontext.Customers.AsNoTracking().AsQueryable();

        public IQueryable<Basket> Baskets => _dbcontext.Baskets.AsNoTracking().AsQueryable();

        public IQueryable<BasketProduct> BasketProducts => _dbcontext.BasketProducts.AsNoTracking().AsQueryable();

        public IQueryable<Product> Products => _dbcontext.Products.AsNoTracking().AsQueryable();

        public IQueryable<ProductStock> ProductStocks => _dbcontext.ProductStocks.AsNoTracking().AsQueryable();
    }
}
