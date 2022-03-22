using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Ddd.Application.Common.Query
{
    public class BaseQuery<TData> : IRequest<GenericResult<TData>>
    {
    }
}
