using System;
using System.Collections.Generic;
using System.Text;

namespace Lolaflora.Baskets.Application.Common
{
    public interface IExecutionContextAccessor
    {
        Guid CorrelationId { get; }
    }
}
