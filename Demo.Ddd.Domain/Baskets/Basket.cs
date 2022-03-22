using Demo.Ddd.Domain.Customers;
using Demo.Ddd.Domain.Customers.Baskets;
using Demo.Ddd.Domain.Customers.Baskets.Rules;
using Demo.Ddd.Domain.Products;
using Demo.Ddd.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Ddd.Domain.Baskets
{
    public class Basket : Entity<Guid>, IAggregateRoot
    {
        public virtual Customer Customer { get; protected set; }
        public virtual Guid CustomerId { get; protected set; }
        public virtual List<BasketProduct> BasketProducts { get; protected set; }
        public DateTime BasketDate { get; protected set; }
        public decimal Value { get; set; }
        protected Basket()
        {
            //FOR ORM
        }
        protected Basket(Customer customer)
        {
            BasketProducts = new List<BasketProduct>();
            Customer = customer;
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