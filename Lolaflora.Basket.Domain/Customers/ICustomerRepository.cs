using Lolaflora.Baskets.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lolaflora.Baskets.Domain.Customers
{
    public interface ICustomerRepository : IEntityRepository<Customer, Guid>
    {
    }
}
