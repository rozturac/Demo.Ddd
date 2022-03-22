using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Ddd.Infrastructure.Common
{
    public class ForeignExchange : IForeignExchange
    {
        public List<ConversionRate> GetConversionRates() => new List<ConversionRate>()
        {
            new ConversionRate(Currency.TRY, Currency.EUR, 1 / 8),
            new ConversionRate(Currency.EUR, Currency.TRY, 8),
            new ConversionRate(Currency.TRY, Currency.USD, 1 / 7),
            new ConversionRate(Currency.USD, Currency.TRY, 7),
            new ConversionRate(Currency.EUR, Currency.USD, 1.2m),
            new ConversionRate(Currency.USD, Currency.EUR, 0.8m),
        };
    }
}
