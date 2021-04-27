using System;
using System.Collections.Generic;
using System.Text;

namespace Lolaflora.Baskets.Domain.Customers.Baskets
{
    public interface IBasketCounter
    {
        int GetProductStockCount(Guid productId);
    }
}
