using Lolaflora.Baskets.Application.Common.Data;
using Lolaflora.Baskets.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lolaflora.Baskets.Infrastructure.Domain.Products
{
    public class ProductCounter : IProductCounter
    {
        private readonly IQueriableRepository _queriableRepository;

        public ProductCounter(IQueriableRepository queriableRepository)
        {
            _queriableRepository = queriableRepository;
        }
        public int GetProductCountByCode(string productCode)
        {
            return _queriableRepository.Products.Count(x => x.Code.ToLower().Equals(productCode.ToLower()));
        }
    }
}
