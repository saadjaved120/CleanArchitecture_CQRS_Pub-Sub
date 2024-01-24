using Demo.CA_CQRS_Pub_Sub.Domain.Events;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Demo.CA_CQRS_Pub_Sub.Infrastructure.RabbitMq
{
    public class RabbitMQService : IEventPublisherService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQService(ConnectionFactory connectionFactory)
        {
            // Create a connection
            _connection = connectionFactory.CreateConnection();
            // Create a channel
            _channel = _connection.CreateModel();

            // Declare the 'blog_events' queue
            _channel.QueueDeclare(queue: "blog_events",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }

        public void PublishNotification(DomainEvent domainEvent)
        {
            var message = JsonConvert.SerializeObject(domainEvent);
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "",
                                     routingKey: "blog_events",
                                     basicProperties: null,
                                     body: body);
        }
    }
}