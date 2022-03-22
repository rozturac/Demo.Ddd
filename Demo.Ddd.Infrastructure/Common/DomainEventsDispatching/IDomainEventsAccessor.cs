
using Demo.Ddd.Domain.SeedWork;
using System.Collections.Generic;

namespace Demo.Ddd.Infrastructure.Common.DomainEventsDispatching
{
    public interface IDomainEventsAccessor
    {
        List<IDomainEvent> GetAllDomainEvents();

        void ClearAllDomainEvents();
    }
}