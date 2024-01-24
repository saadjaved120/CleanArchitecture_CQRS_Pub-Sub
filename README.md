# Clean software design and architecture
## CleanArchitecture, CQRS, MediatR and Pub-Sub

Its a project template which is based on Clean Architecture, Command Query Responsibility Seggrigation and Publisher/Subscriber model guidelines. It elaborate all the concepts by using simple example of a blog entity.

This project uses the RabbitMq as the message broker which can be installed in docker by running following command in cmd:
```sh
docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.12-management.
```

