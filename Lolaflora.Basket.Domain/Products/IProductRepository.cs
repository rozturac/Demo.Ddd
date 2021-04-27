using Lolaflora.Baskets.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lolaflora.Baskets.Domain.Products
{
    public interface IProductRepository : IEntityRepository<Product, Guid>
    {
        Task<Product> GetProductByCode(string productCode);
    }
}
