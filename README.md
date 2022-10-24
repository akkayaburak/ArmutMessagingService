# Armut Messaging Service

## Technologies
- [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [PostgreSQL](https://www.postgresql.org/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [SignalR](https://learn.microsoft.com/en-us/aspnet/core/signalr/introduction?view=aspnetcore-6.0)
- [FluentValidation](https://docs.fluentvalidation.net/en/latest/
)
- [AutoMapper](https://docs.automapper.org/en/stable/)
- [Docker](https://www.docker.com/)


## Installation

```bash
git clone https://github.com/akkayaburak/ArmutMessagingService.git
cd ArmutMessagingService
docker-compose up
```

## Refactors
- Almost all of the ```MessageService``` needs refactor. Highly depends on ```LINQ``` and logic is sensitive.
- Some sort of ```Session``` must be implemented.
- ```ChatHub```needs more error handling.
- Architecture needs to be more clear.

## License
[MIT](https://github.com/akkayaburak/ArmutMessagingService/blob/main/LICENSE)
