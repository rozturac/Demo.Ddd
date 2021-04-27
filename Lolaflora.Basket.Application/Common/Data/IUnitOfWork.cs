using Lolaflora.Baskets.Domain.Customers;
using Lolaflora.Baskets.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lolaflora.Baskets.Application.Common.Data
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        IProductRepository ProductRepository { get; }

        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
