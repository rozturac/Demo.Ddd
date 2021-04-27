using Lolaflora.Baskets.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lolaflora.Baskets.Domain.ForeignExchange
{
    public class ConversionRate
    {
        public Currency SourceCurrency { get; }

        public Currency TargetCurrency { get; }

        public decimal Factor { get; }

        public ConversionRate(Currency sourceCurrency, Currency targetCurrency, decimal factor)
        {
            this.SourceCurrency = sourceCurrency;
            this.TargetCurrency = targetCurrency;
            this.Factor = factor;
        }

        internal MoneyValue Convert(MoneyValue value)
        {
            return this.Factor * value;
        }
    }
}