using Demo.CA_CQRS_Pub_Sub.Application.Common.Notifications;
using Demo.CA_CQRS_Pub_Sub.Domain.Entity;
using Demo.CA_CQRS_Pub_Sub.Domain.Events;
using MediatR;

namespace Demo.CA_CQRS_Pub_Sub.Application.Blogs.EventHandlers
{
    public class BlobDeleteEventHandler : INotificationHandler<DomainEventNotification<EntityDeleteEvent<Blog>>>
    {
        private readonly IEventPublisherService _eventPublisherService;

        public BlobDeleteEventHandler(IEventPublisherService eventPublisherService)
        {
            _eventPublisherService = eventPublisherService;
        }

        public Task Handle(DomainEventNotification<EntityDeleteEvent<Blog>> notification, CancellationToken cancellationToken)
        {
            _eventPublisherService.PublishNotification(notification.DomainEvent);

            return Task.CompletedTask;
        }
    }
}