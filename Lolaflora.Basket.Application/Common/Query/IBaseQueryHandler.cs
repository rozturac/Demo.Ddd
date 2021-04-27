using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lolaflora.Baskets.Application.Common.Query
{
    public interface IBaseQueryHandler<TQuery, TData> : IRequestHandler<TQuery, GenericResult<TData>> where TQuery : BaseQuery<TData>
    {
    }
}