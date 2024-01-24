using Demo.CA_CQRS_Pub_Sub.Domain.Events;
using Demo.CA_CQRS_Pub_Sub.Domain.IRepository;
using Demo.CA_CQRS_Pub_Sub.Infrastructure.Data;
using Demo.CA_CQRS_Pub_Sub.Infrastructure.RabbitMq;
using Demo.CA_CQRS_Pub_Sub.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace Demo.CA_CQRS_Pub_Sub.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)

        {
            services.AddDbContext<BlogDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("BlogDbContext") ??
                    throw new InvalidOperationException("connection string 'BlogDbContext not found '"))
            );

            var rabbitMqConfig = new RabbitMqConfiguration();
            configuration.GetSection(nameof(RabbitMqConfiguration)).Bind(rabbitMqConfig);

            // Configure RabbitMQ service
            services.AddSingleton<IEventPublisherService, RabbitMQService>(provider =>
            {
                var connectionFactory = new ConnectionFactory
                {
                    HostName = rabbitMqConfig.host,
                    UserName = rabbitMqConfig.username,
                    Password = rabbitMqConfig.password,
                };

                return new RabbitMQService(connectionFactory);
            });

            services.AddTransient<IBlogRepository, BlogRepository>();
            return services;
        }
    }
}