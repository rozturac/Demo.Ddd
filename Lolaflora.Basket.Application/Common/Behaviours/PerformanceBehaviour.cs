using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lolaflora.Baskets.Application.Common.Behaviours
{
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger _logger;
        private readonly IExecutionContextAccessor _executionContextAccessor;

        public PerformanceBehaviour(ILogger<TRequest> logger, IExecutionContextAccessor executionContextAccessor)
        {
            _timer = new Stopwatch();
            _logger = logger;
            _executionContextAccessor = executionContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;

            if (elapsedMilliseconds > 500)
            {
                var requestName = typeof(TRequest).Name;
                var correlationId = _executionContextAccessor.CorrelationId;

                _logger.LogWarning("Long Running Request: ({ElapsedMilliseconds} milliseconds) {@CorrelationId} {@Request}",
                    requestName, elapsedMilliseconds, correlationId, request);
            }

            return response;
        }
    }
}