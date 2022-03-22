using Demo.Ddd.Domain.Customers;
using Demo.Ddd.Domain.SeedWork;
using Demo.Ddd.Infrastructure.Common.Data;
using Demo.Ddd.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Ddd.Infrastructure.Domain.Customers
{
    public class CustomerRepository : EFEntityRepositoryBase<Customer, Guid>, ICustomerRepository
    {
        public CustomerRepository(BasketContext dbContext) : base(dbContext)
        {
        }
    }
}
