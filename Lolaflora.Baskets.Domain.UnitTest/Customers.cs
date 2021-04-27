using Lolaflora.Baskets.Domain.Customers;
using Lolaflora.Baskets.Domain.Customers.Baskets;
using Lolaflora.Baskets.Domain.Products;
using Lolaflora.Baskets.Domain.SeedWork;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lolaflora.Baskets.Domain.UnitTest
{
    public class Customers
    {
        [Test]
        public void customer_create_test_is_success()
        {
            var customerCounter = Substitute.For<ICustomerCounter>();
            customerCounter.GetCustomerCountByEmail("test@test.com").Returns(0);
            var product = Customer.CreateRegistered("test", "test@test.com", customerCounter);

            Assert.AreEqual("test@test.com", product.Email);
        }

        [Test]
        public void customer_create_test_is_not_success()
        {
            var customerCounter = Substitute.For<ICustomerCounter>();
            customerCounter.GetCustomerCountByEmail("test@test.com").Returns(1);

            Assert.Throws<BusinessRuleValidationException>(() =>
            {
                Customer.CreateRegistered("test", "test@test.com", customerCounter);
            });
        }

        [Test]
        public void customer_basket_add_item_test_is_success()
        {
            var productCounter = Substitute.For<IProductCounter>();
            productCounter.GetProductCountByCode("TP1").Returns(0);
            var product = Product.Create("TP1", "Test Product 1", 75.15M, 20, productCounter);

            var basketCounter = Substitute.For<IBasketCounter>();
            basketCounter.GetProductStockCount(product.Id).Returns(50);

            var customer = Customer.CreateGuest();
            int quantity = 50;
            customer.Basket.AddProduct(product.GetProductPriceData(), quantity, basketCounter);

            Assert.AreEqual(customer.Basket.Value, product.UnitPrice * quantity);
        }

        [Test]
        public void customer_basket_add_item_test_is_failed()
        {
            var productCounter = Substitute.For<IProductCounter>();
            productCounter.GetProductCountByCode("TP1").Returns(0);
            var product = Product.Create("TP1", "Test Product 1", 75.15M, 20, productCounter);

            var basketCounter = Substitute.For<IBasketCounter>();
            basketCounter.GetProductStockCount(product.Id).Returns(20);

            Assert.Throws<BusinessRuleValidationException>(() =>
            {
                var customer = Customer.CreateGuest();
                int quantity = 50;
                customer.Basket.AddProduct(product.GetProductPriceData(), quantity, basketCounter);
            });
        }

    }
}
