using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lolaflora.Baskets.Application.Common.Query
{
    public class BaseQuery<TData> : IRequest<GenericResult<TData>>
    {
    }
}
