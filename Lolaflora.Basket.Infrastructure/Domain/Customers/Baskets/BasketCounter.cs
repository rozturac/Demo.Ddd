using Lolaflora.Baskets.Application.Common.Data;
using Lolaflora.Baskets.Domain.Baskets;
using Lolaflora.Baskets.Domain.Customers.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lolaflora.Baskets.Infrastructure.Domain.Customers.Baskets
{
    public class BasketCounter : IBasketCounter
    {
        private readonly IQueriableRepository _queriableRepository;

        public BasketCounter(IQueriableRepository queriableRepository)
        {
            _queriableRepository = queriableRepository;
        }

        public int GetProductStockCount(Guid productId)
        {
            return _queriableRepository.ProductStocks.Where(x => x.ProductId == productId).Sum(x => x.Quentity)
                - _queriableRepository.BasketProducts.Where(x => x.ProductId == productId).Sum(x => x.Quantity);
        }
    }
}