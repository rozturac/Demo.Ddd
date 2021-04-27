using System;
using System.Collections.Generic;
using System.Text;

namespace Lolaflora.Baskets.Domain.Customers
{
    public interface ICustomerCounter
    {
        int GetCustomerCountByEmail(string email);
    }
}
