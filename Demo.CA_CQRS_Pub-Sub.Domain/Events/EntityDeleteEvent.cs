namespace Demo.CA_CQRS_Pub_Sub.Domain.Events
{
    public class EntityDeleteEvent<T> : DomainEvent where T : IHasDomainEvent
    {
        public EntityDeleteEvent(T item)
        {
            EventType = typeof(EntityDeleteEvent<T>).Name.Split('`')[0];
            Entity = typeof(EntityDeleteEvent<T>).GetGenericArguments().FirstOrDefault()?.Name ?? "";
            Item = item;
        }

        public T Item { get; }
    }
}