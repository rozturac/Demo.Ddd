using Lolaflora.Baskets.Application.Common.Data;
using Lolaflora.Baskets.Domain.Customers;
using Lolaflora.Baskets.Domain.Products;
using Lolaflora.Baskets.Infrastructure.Common.DomainEventsDispatching;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lolaflora.Baskets.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IDomainEventsDispatcher _domainEventsDispatcher;
        private readonly BasketContext _dbContext;
        public UnitOfWork(ICustomerRepository customerRepository,
            IProductRepository productRepository,
            IDomainEventsDispatcher domainEventsDispatcher,
            BasketContext dbContext)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _domainEventsDispatcher = domainEventsDispatcher;
            _dbContext = dbContext;
        }

        public ICustomerRepository CustomerRepository => _customerRepository;

        public IProductRepository ProductRepository => _productRepository;

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            await _domainEventsDispatcher.DispatchEventsAsync();
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
