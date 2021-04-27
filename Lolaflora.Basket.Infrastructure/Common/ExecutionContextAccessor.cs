using Lolaflora.Baskets.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lolaflora.Baskets.Infrastructure.Common
{
    public class ExecutionContextAccessor : IExecutionContextAccessor
    {
        private readonly Guid _correlationId;
        public ExecutionContextAccessor()
        {
            _correlationId = Guid.NewGuid();
        }

        public Guid CorrelationId => _correlationId;
    }
}