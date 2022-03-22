using Demo.Ddd.Domain.Products.Rules;
using Demo.Ddd.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using Demo.Ddd.Domain.Products.Events;
using Demo.Ddd.Domain.SharedKernel;

namespace Demo.Ddd.Domain.Products
{
    public sealed class Product : Entity<Guid>, IAggregateRoot
    {
        public string Name { get; protected set; }
        public string Code { get; protected set; }
        public MoneyValue UnitPrice { get; protected set; }
        public List<ProductStock> ProductStocks { get; protected set; }

        private Product(string name, string code, MoneyValue unitPrice, int productStockQuentity, IProductCounter productCounter)
        {
            CheckRule(new ProductCodeMustBeUniqueRole(productCounter, code));

            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            ProductStocks = new List<ProductStock>() { ProductStock.Create(productStockQuentity, this) };
            
            AddDomainEvent(ProductCreated.Create(this));
        }

        private Product(string name, string code, MoneyValue unitPrice, IProductCounter productCounter)
        {
            CheckRule(new ProductCodeMustBeUniqueRole(productCounter, code));

            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            ProductStocks = new List<ProductStock>();
        }

        public static Product Create(string name, string code, MoneyValue unitPrice, int productStockQuantity, IProductCounter productCounter) => new Product(name, code, unitPrice, productStockQuantity, productCounter);
        public static Product Create(string name, string code, MoneyValue unitPrice, IProductCounter productCounter) => new Product(name, code, unitPrice, productCounter);
        public void AddStock(int quentity) => ProductStocks.Add(ProductStock.Create(quentity, this));

        public ProductPriceData GetProductPriceData() => ProductPriceData.Create(Id, UnitPrice);
    }
}