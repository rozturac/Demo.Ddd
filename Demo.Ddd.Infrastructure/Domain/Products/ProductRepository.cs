using Demo.Ddd.Domain.Products;
using Demo.Ddd.Infrastructure.Common.Data;
using Demo.Ddd.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Ddd.Infrastructure.Domain.Products
{
    public class ProductRepository : EFEntityRepositoryBase<Product, Guid>, IProductRepository
    {
        public ProductRepository(BasketContext dbContext) : base(dbContext)
        {
        }

        public async Task<Product> GetProductByCode(string productCode)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Code == productCode);
        }
    }
}
