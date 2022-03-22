using Demo.Ddd.Domain.Customers;
using Demo.Ddd.Domain.Customers.Baskets;
using Demo.Ddd.Domain.Customers.Baskets.Rules;
using Demo.Ddd.Domain.Products;
using Demo.Ddd.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Demo.Ddd.Domain.SharedKernel;

namespace Demo.Ddd.Domain.Baskets
{
    public sealed class Basket : Entity<Guid>, IAggregateRoot
    {
        public Customer Customer { get; }
        public Guid CustomerId { get; protected set; }
        public List<BasketProduct> BasketProducts { get; }
        public DateTime CreatedDate { get; }
        public MoneyValue Value { get; set; }

        private Basket(Customer customer)
        {
            BasketProducts = new List<BasketProduct>();
            Customer = customer;
            CreatedDate = DateTime.Now;
        }

        internal static Basket CreateNew(Customer customer) => new Basket(customer);

        public void AddProduct(ProductPriceData productPrices, int quantity, IBasketCounter basketCounter)
        {
            BasketProducts.Add(BasketProduct.CreateForProduct(this, productPrices, quantity, basketCounter));

            CalculateBasketValue();
        }

        private void CalculateBasketValue()
        {
            Value = BasketProducts.Sum(x => x.Value);
        }
    }
}