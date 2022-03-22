using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace  Demo.Ddd.Application.Common.Command
{
    public interface IBaseCommandHandler<TCommand, TData> : IRequestHandler<TCommand, GenericResult<TData>> where TCommand : BaseCommand<TData>
    {

    }
}
