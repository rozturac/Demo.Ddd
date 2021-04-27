using Lolaflora.Baskets.Application.Common.Data;
using Lolaflora.Baskets.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lolaflora.Baskets.Infrastructure.Domain.Customers
{
    public class CustomerCounter : ICustomerCounter
    {
        private readonly IQueriableRepository _queriableRepository;

        public CustomerCounter(IQueriableRepository queriableRepository)
        {
            _queriableRepository = queriableRepository;
        }

        public int GetCustomerCountByEmail(string email)
        {
            return _queriableRepository.Customers.Count(x => x.Email.ToLower().Equals(email.ToLower()));
        }
    }
}
