using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Ddd.Domain.Customers
{
    public interface ICustomerCounter
    {
        int GetCustomerCountByEmail(string email);
    }
}
