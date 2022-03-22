using Demo.Ddd.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Ddd.Domain.Products.Rules
{
    public class ProductCodeMustBeUniqueRole : IBusinessRule
    {
        private readonly IProductCounter _productCounter;
        private readonly string _productCode;

        public ProductCodeMustBeUniqueRole(IProductCounter productCounter, string productCode)
        {
            _productCounter = productCounter;
            _productCode = productCode;
        }

        public string Message => "ProductCode must be unique";

        public bool IsBroken() => _productCounter.GetProductCountByCode(_productCode) > 0;
    }
}