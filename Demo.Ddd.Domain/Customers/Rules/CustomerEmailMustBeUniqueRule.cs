using Demo.Ddd.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Ddd.Domain.Customers
{
    public class CustomerEmailMustBeUniqueRule : IBusinessRule
    {
        private readonly ICustomerCounter _customerCounter;
        private readonly string _email;
        public CustomerEmailMustBeUniqueRule(ICustomerCounter customerCounter, string email)
        {
            _customerCounter = customerCounter;
            _email = email;
        }

        public string Message => "Emeil Address Must Be Unique";

        public bool IsBroken() => _customerCounter.GetCustomerCountByEmail(_email) > 0;
    }
}
