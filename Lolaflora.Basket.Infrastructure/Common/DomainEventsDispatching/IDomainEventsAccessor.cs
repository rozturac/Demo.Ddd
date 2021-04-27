
using Lolaflora.Baskets.Domain.SeedWork;
using System.Collections.Generic;

namespace Lolaflora.Baskets.Infrastructure.Common.DomainEventsDispatching
{
    public interface IDomainEventsAccessor
    {
        List<IDomainEvent> GetAllDomainEvents();

        void ClearAllDomainEvents();
    }
}