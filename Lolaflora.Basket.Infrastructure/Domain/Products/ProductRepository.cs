using Lolaflora.Baskets.Domain.Products;
using Lolaflora.Baskets.Infrastructure.Common.Data;
using Lolaflora.Baskets.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lolaflora.Baskets.Infrastructure.Domain.Products
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
