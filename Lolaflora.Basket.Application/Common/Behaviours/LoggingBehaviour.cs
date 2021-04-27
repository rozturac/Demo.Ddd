using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lolaflora.Baskets.Application.Common.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public LoggingBehaviour(ILogger<TRequest> logger, IExecutionContextAccessor executionContextAccessor)
        {
            _logger = logger;
            _executionContextAccessor = executionContextAccessor;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var correlationId = _executionContextAccessor.CorrelationId;

            _logger.LogInformation("Request: {Name} {@CorrelationId} {@Request}",
                requestName, correlationId, request);

            return Task.CompletedTask;
        }
    }
}