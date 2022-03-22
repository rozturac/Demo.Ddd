using Demo.Ddd.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Ddd.Application.Common.Notification
{
    public class DomainEventNotification<TDomainEvent> : INotification where TDomainEvent : IDomainEvent
    {
        public DomainEventNotification(TDomainEvent domainEvent)
        {
            DomainEvent = domainEvent;
        }

        public TDomainEvent DomainEvent { get; }
    }
}