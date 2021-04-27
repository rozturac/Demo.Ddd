using Lolaflora.Baskets.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lolaflora.Baskets.Domain.Customers.Baskets.Rules
{
    public class BasketQuantityCanNotExceedTheProductStockCountRule : IBusinessRule
    {
        private readonly Guid _productId;
        private readonly int _quentity;
        private readonly IBasketCounter _basketCounter;

        public BasketQuantityCanNotExceedTheProductStockCountRule(Guid productId, int quentity, IBasketCounter basketCounter)
        {
            _productId = productId;
            _quentity = quentity;
            _basketCounter = basketCounter;
        }

        public string Message => "Order quantity can't exceed the product stock count";

        public bool IsBroken() => _basketCounter.GetProductStockCount(_productId) < _quentity;
    }
}