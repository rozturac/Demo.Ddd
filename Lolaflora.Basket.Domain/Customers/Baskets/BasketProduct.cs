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
    public class BasketProduct : Entity<Guid>
    {
        public virtual Basket Basket { get; protected set; }
        public Guid ProductId { get; protected set; }
        public decimal Value { get; set; }
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