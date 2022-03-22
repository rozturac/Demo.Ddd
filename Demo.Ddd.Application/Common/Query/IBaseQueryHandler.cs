using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Ddd.Application.Common.Query
{
    public interface IBaseQueryHandler<TQuery, TData> : IRequestHandler<TQuery, GenericResult<TData>> where TQuery : BaseQuery<TData>
    {
    }
}