using Demo.Ddd.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Ddd.Domain.Customers
{
    public interface ICustomerRepository : IEntityRepository<Customer, Guid>
    {
    }
}
