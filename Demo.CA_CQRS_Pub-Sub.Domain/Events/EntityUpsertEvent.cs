namespace Demo.CA_CQRS_Pub_Sub.Domain.Events;

public class EntityUpsertEvent<T> : DomainEvent where T : IHasDomainEvent
{
    public EntityUpsertEvent(T item)
    {
        EventType = typeof(EntityUpsertEvent<T>).Name.Split('`')[0];
        Entity = typeof(EntityUpsertEvent<T>).GetGenericArguments().FirstOrDefault()?.Name ?? "";
        Item = item;
    }

    public T Item { get; }
}