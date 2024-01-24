namespace Demo.CA_CQRS_Pub_Sub.Domain.Events
{
    // todo: move this interface from domain layer to CrossCuttingCorner layer (it is here atm for similicity)
    public interface IEventPublisherService
    {
        void PublishNotification(DomainEvent domainEvent);
    }
}