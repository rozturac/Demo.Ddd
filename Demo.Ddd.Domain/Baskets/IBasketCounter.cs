using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Ddd.Domain.Customers.Baskets
{
    public interface IBasketCounter
    {
        int GetProductStockCount(Guid productId);
    }
}
