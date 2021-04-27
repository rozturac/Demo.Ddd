using System;
using System.Collections.Generic;
using System.Text;

namespace Lolaflora.Baskets.Domain.ForeignExchange
{
    public interface IForeignExchange
    {
        List<ConversionRate> GetConversionRates();
    }
}