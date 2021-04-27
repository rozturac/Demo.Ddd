using Lolaflora.Baskets.Application.Common.Data;
using Lolaflora.Baskets.Domain.Baskets;
using Lolaflora.Baskets.Domain.Customers;
using Lolaflora.Baskets.Domain.Products;
using Lolaflora.Baskets.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lolaflora.Baskets.Infrastructure.Common.Data
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
