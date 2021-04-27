using Lolaflora.Baskets.Domain.Customers;
using Lolaflora.Baskets.Domain.SeedWork;
using Lolaflora.Baskets.Infrastructure.Common.Data;
using Lolaflora.Baskets.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lolaflora.Baskets.Infrastructure.Domain.Customers
{
    public class CustomerRepository : EFEntityRepositoryBase<Customer, Guid>, ICustomerRepository
    {
        public CustomerRepository(BasketContext dbContext) : base(dbContext)
        {
        }
    }
}
