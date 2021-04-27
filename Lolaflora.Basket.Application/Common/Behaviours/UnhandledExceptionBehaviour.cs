using Lolaflora.Baskets.Application.Common.Exceptions;
using Lolaflora.Baskets.Domain.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lolaflora.Baskets.Application.Common.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    {
        private readonly ILogger _logger;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public UnhandledExceptionBehaviour(ILogger<TRequest> logger, IExecutionContextAccessor executionContextAccessor)
        {
            _logger = logger;
            _executionContextAccessor = executionContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
           
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogError(ex, "Request: Exception for Request {@CorrelationId} {Name} {@Request}", _executionContextAccessor.CorrelationId, requestName, request);
                throw;
            }
        }
    }
}