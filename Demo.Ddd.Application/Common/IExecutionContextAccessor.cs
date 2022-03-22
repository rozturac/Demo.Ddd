using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Ddd.Application.Common
{
    public interface IExecutionContextAccessor
    {
        Guid CorrelationId { get; }
    }
}
