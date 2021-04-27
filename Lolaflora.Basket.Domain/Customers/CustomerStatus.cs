using Lolaflora.Baskets.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lolaflora.Baskets.Domain.Customers
{
    public class CustomerStatus : Enumeration
    {
        public readonly static CustomerStatus Guest = new CustomerStatus(1, nameof(Guest));
        public readonly static CustomerStatus Registered = new CustomerStatus(1, nameof(Registered));

        public CustomerStatus(int value, string name) : base(value, name)
        {
        }
    }
}
