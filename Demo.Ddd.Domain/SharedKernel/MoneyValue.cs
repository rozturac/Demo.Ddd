using Demo.Ddd.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Ddd.Domain.SharedKernel
{
    public class MoneyValue : ValueObject
    {
        public decimal Value { get; }

        public Currency Currency { get; }

        private MoneyValue(decimal value, Currency currency)
        {
            this.Value = value;
            this.Currency = currency;
        }

        public static MoneyValue Of(decimal value, Currency currency)
        {
            CheckRule(new MoneyValueMustHaveCurrencyRule(currency));

            return new MoneyValue(value, currency);
        }

        public static MoneyValue Of(MoneyValue value)
        {
            return new MoneyValue(value.Value, value.Currency);
        }

        public static MoneyValue operator +(MoneyValue moneyValueLeft, MoneyValue moneyValueRight)
        {
            CheckRule(new MoneyValueOperationMustBePerformedOnTheSameCurrencyRule(moneyValueLeft, moneyValueRight));

            return new MoneyValue(moneyValueLeft.Value + moneyValueRight.Value, moneyValueLeft.Currency);
        }

        public static MoneyValue operator *(int number, MoneyValue moneyValueRight)
        {
            return new MoneyValue(number * moneyValueRight.Value, moneyValueRight.Currency);
        }

        public static MoneyValue operator *(decimal number, MoneyValue moneyValueRight)
        {
            return new MoneyValue(number * moneyValueRight.Value, moneyValueRight.Currency);
        }
        
        public static MoneyValue operator *(MoneyValue moneyValueRight, int number)
        {
            return new MoneyValue(number * moneyValueRight.Value, moneyValueRight.Currency);
        }

        public static MoneyValue operator *(MoneyValue moneyValueRight, decimal number)
        {
            return new MoneyValue(number * moneyValueRight.Value, moneyValueRight.Currency);
        }
    }

    public static class SumExtensions
    {
        public static MoneyValue Sum<T>(this IEnumerable<T> source, Func<T, MoneyValue> selector)
        {
            return MoneyValue.Of(source.Select(selector).Aggregate((x, y) => x + y));
        }

        public static MoneyValue Sum(this IEnumerable<MoneyValue> source)
        {
            return source.Aggregate((x, y) => x + y);
        }
    }
}