using Lolaflora.Baskets.Domain.SeedWork;
using Lolaflora.Baskets.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lolaflora.Baskets.Domain.Products.Rules
{
    public class ProductPriceCurrencyMustBeTRYRole :IBusinessRule
    {
        private readonly Currency _currency;
        public ProductPriceCurrencyMustBeTRYRole(Currency currency)
        {
            _currency = currency;
        }

        public string Message => "Product price currency type must be TRY";

        public bool IsBroken() => _currency != Currency.TRY;
    }
}
