﻿using Demo.Ddd.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Ddd.Domain.SharedKernel
{
    public class MoneyValueOperationMustBePerformedOnTheSameCurrencyRule : IBusinessRule
    {
        private readonly MoneyValue _left;

        private readonly MoneyValue _right;

        public MoneyValueOperationMustBePerformedOnTheSameCurrencyRule(MoneyValue left, MoneyValue right)
        {
            _left = left;
            _right = right;
        }

        public bool IsBroken() => _left.Currency != _right.Currency;

        public string Message => "Money value currencies must be the same";
    }
}