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
    public class BasketProduct : Entity<Guid>
    {
        public virtual Basket Basket { get; protected set; }
        public Guid ProductId { get; protected set; }
        public MoneyValue Value { get; set; }
        public int Quantity { get; protected set; }

        protected BasketProduct()
        {
            //FOR ORM
        }

        private BasketProduct(Basket basket, ProductPriceData productPrice, int quantity, IBasketCounter basketCounter)
        {
            CheckRule(new BasketQuantityCanNotExceedTheProductStockCountRule(productPrice.ProductId, quantity, basketCounter));

            Basket = basket;
            ProductId = productPrice.ProductId;
            Quantity = quantity;

            CalculateValue(productPrice);
        }

        internal static BasketProduct CreateForProduct(Basket basket, ProductPriceData productPrice, int quantity, IBasketCounter basketCounter) => new BasketProduct(basket, productPrice, quantity, basketCounter);

        internal void ChangeQuantity(ProductPriceData productPrice, int quantity, IBasketCounter basketCounter)
        {
            CheckRule(new BasketQuantityCanNotExceedTheProductStockCountRule(productPrice.ProductId, quantity, basketCounter));

            Quantity = quantity;

            CalculateValue(productPrice);
        }

        private void CalculateValue(ProductPriceData productPrice)
        {
            Value = Quantity * productPrice.Price;
        }
    }
}