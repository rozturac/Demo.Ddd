using Lolaflora.Baskets.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lolaflora.Baskets.Domain.SharedKernel
{
    public class MoneyValueMustHaveCurrencyRule : IBusinessRule
    {
        private readonly Currency _currency;

        public MoneyValueMustHaveCurrencyRule(Currency currency)
        {
            _currency = currency;
        }

        public bool IsBroken() => _currency == null;

        public string Message => "Money value must have currency";
    }
}