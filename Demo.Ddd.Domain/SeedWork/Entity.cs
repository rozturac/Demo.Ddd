using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.Ddd.Domain.SeedWork
{
    public class Entity<TPrimaryKey> : IDomainEntity 
        where TPrimaryKey : struct
    {
        [Key]
        public virtual TPrimaryKey Id { get; protected set; }

        [IgnoreMember]
        private List<IDomainEvent> _domainEvents;

        [IgnoreMember]
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();
        public EntityStatus Status { get; protected set; } = EntityStatus.Active;
        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents = _domainEvents ?? new List<IDomainEvent>();
            _domainEvents.Add(domainEvent);
        }

        protected void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }

        public void Active() => Status = EntityStatus.Active;
        public void Passive() => Status = EntityStatus.Passive;
        public void Deleted() => Status = EntityStatus.Deleted;
    }

    public interface IDomainEntity
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
        void ClearDomainEvents();
        void AddDomainEvent(IDomainEvent domainEvent);
    }
}
