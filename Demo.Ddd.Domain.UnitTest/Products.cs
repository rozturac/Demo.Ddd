using Demo.Ddd.Domain.Products;
using Demo.Ddd.Domain.SeedWork;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Demo.Ddd.Domain.SharedKernel;

namespace Demo.Ddd.Domain.UnitTest
{
    public class Products
    {
        [Test]
        public void product_create_test_is_success()
        {
            var productCounter = Substitute.For<IProductCounter>();
            productCounter.GetProductCountByCode("TP1").Returns(0);
            var product = Product.Create("Test Product 1", "TP1", MoneyValue.Of(75.15M, Currency.TRY), 20, productCounter);

            Assert.AreEqual("TP1", product.Code);
        }

        [Test]
        public void product_create_test_is_not_success()
        {
            var productCounter = Substitute.For<IProductCounter>();
            productCounter.GetProductCountByCode("TP1").Returns(1);

            Assert.Throws<BusinessRuleValidationException>(() =>
            {
                Product.Create("Test Product 1", "TP1", MoneyValue.Of(75.15M, Currency.TRY), 20, productCounter);
            });
        }
    }
}
