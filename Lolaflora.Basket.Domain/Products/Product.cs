using Lolaflora.Baskets.Domain.Products.Rules;
using Lolaflora.Baskets.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lolaflora.Baskets.Domain.Products
{
    public class Product : Entity<Guid>, IAggregateRoot
    {
        public string Name { get; protected set; }
        public string Code { get; protected set; }
        public decimal UnitPrice { get; protected set; }
        public virtual List<ProductStock> ProductStocks { get; protected set; }

        protected Product()
        {
            //FOR ORM
        }
        protected Product(string name, string code, decimal unitPrice, int productStockQuentity, IProductCounter productCounter)
        {
            CheckRule(new ProductCodeMustBeUniqueRole(productCounter, code));

            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            ProductStocks = new List<ProductStock>() { ProductStock.Create(productStockQuentity, this) };
        }

        protected Product(string name, string code, decimal unitPrice, IProductCounter productCounter)
        {
            CheckRule(new ProductCodeMustBeUniqueRole(productCounter, code));

            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            ProductStocks = new List<ProductStock>();
        }

        public static Product Create(string name, string code, decimal unitPrice, int productStockQuentity, IProductCounter productCounter) => new Product(name, code, unitPrice, productStockQuentity, productCounter);
        public static Product Create(string name, string code, decimal unitPrice, IProductCounter productCounter) => new Product(name, code, unitPrice, productCounter);
        public void AddStock(int quentity) => ProductStocks.Add(ProductStock.Create(quentity, this));

        public ProductPriceData GetProductPriceData() => ProductPriceData.Create(Id, UnitPrice);
    }
}