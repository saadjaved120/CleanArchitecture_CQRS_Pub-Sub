using Demo.CA_CQRS_Pub_Sub.Domain.Events;
using MediatR;

namespace Demo.CA_CQRS_Pub_Sub.Application.Common.Notifications;

/// <summary>
/// Wrapper over DomainEvent to contain MediatorR dependency only to application layer
/// </summary>
/// <typeparam name="TDomainEvent"></typeparam>
public class DomainEventNotification<TDomainEvent> : INotification where TDomainEvent : DomainEvent
{
    public DomainEventNotification(TDomainEvent domainEvent)
    {
        DomainEvent = domainEvent;
    }

    public TDomainEvent DomainEvent { get; }
}