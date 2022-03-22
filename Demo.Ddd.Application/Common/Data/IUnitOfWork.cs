using Demo.Ddd.Domain.Customers;
using Demo.Ddd.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Ddd.Application.Common.Data
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        IProductRepository ProductRepository { get; }

        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
