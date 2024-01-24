using Demo.CA_CQRS_Pub_Sub.Application.Common.Notifications;
using Demo.CA_CQRS_Pub_Sub.Domain.Entity;
using Demo.CA_CQRS_Pub_Sub.Domain.Events;
using MediatR;

namespace Demo.CA_CQRS_Pub_Sub.Application.Blogs.EventHandlers
{
    public class BlobUpsertEventHandler : INotificationHandler<DomainEventNotification<EntityUpsertEvent<Blog>>>
    {
        private readonly IEventPublisherService _eventPublisherService;

        public BlobUpsertEventHandler(IEventPublisherService eventPublisherService)
        {
            _eventPublisherService = eventPublisherService;
        }

        public Task Handle(DomainEventNotification<EntityUpsertEvent<Blog>> notification, CancellationToken cancellationToken)
        {
            _eventPublisherService.PublishNotification(notification.DomainEvent);

            return Task.CompletedTask;
        }
    }
}