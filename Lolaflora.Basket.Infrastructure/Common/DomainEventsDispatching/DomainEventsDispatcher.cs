using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Lolaflora.Baskets.Infrastructure.Common.DomainEventsDispatching
{
public class DomainEventsDispatcher : IDomainEventsDispatcher
    {
        private readonly IMediator _mediator;
        private readonly IDomainEventsAccessor _domainEventsProvider;

        public DomainEventsDispatcher(
            IMediator mediator, 
            IDomainEventsAccessor domainEventsProvider)
        {
            this._mediator = mediator;
            _domainEventsProvider = domainEventsProvider;
        }

        public async Task DispatchEventsAsync()
        {
            var domainEvents = _domainEventsProvider.GetAllDomainEvents();

            _domainEventsProvider.ClearAllDomainEvents();

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await _mediator.Publish(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}