using Lolaflora.Baskets.Domain.Customers;
using Lolaflora.Baskets.Domain.Customers.Baskets;
using Lolaflora.Baskets.Domain.Customers.Baskets.Rules;
using Lolaflora.Baskets.Domain.Products;
using Lolaflora.Baskets.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lolaflora.Baskets.Domain.Baskets
{
    public class Basket : Entity<Guid>
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