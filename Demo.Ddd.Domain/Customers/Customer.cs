using Demo.Ddd.Domain.Baskets;
using Demo.Ddd.Domain.Customers.Baskets;
using Demo.Ddd.Domain.Products;
using Demo.Ddd.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Ddd.Domain.Customers
{
    public class Customer : Entity<Guid>, IAggregateRoot
    {
        public string Email { get; protected set; }
        public string Name { get; protected set; }
        public virtual Basket Basket { get; protected set; }
        public CustomerStatus CustomerStatus { get; protected set; }

        protected Customer()
        {
            CustomerStatus = CustomerStatus.Guest;
            Basket = Basket.CreateNew(this);
        }

        protected Customer(string name, string email, ICustomerCounter customerCounter)
        {
            CheckRule(new CustomerEmailMustBeUniqueRule(customerCounter, email));

            Name = name;
            Email = email;
            CustomerStatus = CustomerStatus.Registered;
            Basket = Basket.CreateNew(this);
        }

        public static Customer CreateGuest() => new Customer();
        public static Customer CreateRegistered(string name, string email, ICustomerCounter customerCounter) => new Customer(name, email, customerCounter);
    }
}
