using Demo.CA_CQRS_Pub_Sub.Domain.Events;

namespace Demo.CA_CQRS_Pub_Sub.Domain.Entity
{
    public class Blog : IHasDomainEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}