namespace Demo.CA_CQRS_Pub_Sub.Domain.Events;

public abstract class DomainEvent
{
    protected DomainEvent()
    {
        DateOccurred = DateTimeOffset.UtcNow;
    }

    public DateTimeOffset DateOccurred { get; protected set; } = DateTime.UtcNow;
    public string EventType { get; protected set; }
    public string Entity { get; protected set; }
}