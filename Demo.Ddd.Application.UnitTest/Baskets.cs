using Demo.Ddd.Application.Baskets.AddItemCommand;
using Demo.Ddd.Application.Common.Data;
using Demo.Ddd.Application.Common.Exceptions;
using Demo.Ddd.Domain.Customers;
using Demo.Ddd.Domain.Customers.Baskets;
using Demo.Ddd.Domain.Products;
using Demo.Ddd.Domain.SeedWork;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Ddd.Application.UnitTest
{
    public class Baskets
    {
        [Test]
        public async Task add_item_to_basket_command_test_is_success()
        {
            var command = new AddItemToBasketCommand()
            {
                CustomerId = null,
                ProductCode = "TP1",
                Quantity = 50
            };

            var productCounter = Substitute.For<IProductCounter>();
            productCounter.GetProductCountByCode("TP1").Returns(0);
            var product = Product.Create("Test Product 1", "TP1", 75.15M, 20, productCounter);

            var basketCounter = Substitute.For<IBasketCounter>();
            basketCounter.GetProductStockCount(product.Id).Returns(50);

            var uow = Substitute.For<IUnitOfWork>();
            uow.ProductRepository.GetById(product.Id).Returns(product);
            uow.ProductRepository.GetProductByCode(product.Code).Returns(product);
            uow.CustomerRepository.AddAsync(Customer.CreateGuest()).Returns(Task.CompletedTask);
            uow.CommitAsync(new System.Threading.CancellationToken()).Returns(1);

            var handler = new AddItemToBasketCommandHandler(uow, basketCounter);

            var response = await handler.Handle(command, new System.Threading.CancellationToken());

            Assert.IsTrue(response.Succeeded);
            Assert.AreEqual(response.Data.Value, product.UnitPrice * command.Quantity);
        }

        [Test]
        public void add_item_to_basket_command_test_is_not_success_because_of_not_found()
        {
            var command = new AddItemToBasketCommand()
            {
                CustomerId = null,
                ProductCode = "TP2",
                Quantity = 50
            };

            var productCounter = Substitute.For<IProductCounter>();
            productCounter.GetProductCountByCode("TP1").Returns(0);
            var product = Product.Create("Test Product 1", "TP1", 75.15M, 20, productCounter);

            var basketCounter = Substitute.For<IBasketCounter>();
            basketCounter.GetProductStockCount(product.Id).Returns(50);

            var uow = Substitute.For<IUnitOfWork>();
            uow.ProductRepository.GetById(product.Id).Returns(product);
            uow.ProductRepository.GetProductByCode(product.Code).Returns(product);
            uow.CustomerRepository.AddAsync(Customer.CreateGuest()).Returns(Task.CompletedTask);
            uow.CommitAsync(new System.Threading.CancellationToken()).Returns(1);

            var handler = new AddItemToBasketCommandHandler(uow, basketCounter);

            Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(command, new System.Threading.CancellationToken());
            });
        }
    }
}
