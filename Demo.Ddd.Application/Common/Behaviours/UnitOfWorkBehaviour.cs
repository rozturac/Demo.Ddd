using Demo.Ddd.Application.Common.Command;
using Demo.Ddd.Application.Common.Data;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Ddd.Application.Common.Behaviours
{
    public class UnitOfWorkBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : class
    {
        private readonly IUnitOfWork _uow;

        public UnitOfWorkBehaviour(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = await next();

            if (request.GetType().GetInterfaces().Contains(typeof(ICommand)))
                await _uow.CommitAsync(cancellationToken);

            return response;         
        }
    }
}
