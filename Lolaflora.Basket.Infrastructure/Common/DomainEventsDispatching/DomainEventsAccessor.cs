using System.Collections.Generic;
using System.Linq;
using Lolaflora.Baskets.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Lolaflora.Baskets.Infrastructure.Common.DomainEventsDispatching
{
    public class DomainEventsAccessor : IDomainEventsAccessor
    {
        private readonly DbContext _dbContext;

        public DomainEventsAccessor(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<IDomainEvent> GetAllDomainEvents()
        {
           return this._dbContext.ChangeTracker
                .Entries<IDomainEntity>()
                .Where(x => x.Entity.DomainEvents?.Any() == true)
                .SelectMany(x=> x.Entity.DomainEvents)
                .ToList();
        }

        public void ClearAllDomainEvents()
        {
            var domainEntities = this._dbContext.ChangeTracker
                .Entries<IDomainEntity>()
                .Where(x => x.Entity.DomainEvents?.Any() == true)
                .ToList();

            domainEntities
                .ForEach(entity => entity.Entity.ClearDomainEvents());
        }
    }
}