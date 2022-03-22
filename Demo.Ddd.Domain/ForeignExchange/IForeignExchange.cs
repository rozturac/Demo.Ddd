using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Ddd.Domain.ForeignExchange
{
    public interface IForeignExchange
    {
        List<ConversionRate> GetConversionRates();
    }
}