using System.Text.Json;
using Contracts;
using Consumers;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.Messaging;

public class FakeMessageBus : IMessageBus
{
    private readonly IServiceProvider _serviceProvider;

    public FakeMessageBus(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public async Task PublishAsync(IIntegrationEvent message)
    {
        Console.WriteLine("=== EVENT PUBLISHED ===");
        Console.WriteLine(JsonSerializer.Serialize(message, message!.GetType(), new JsonSerializerOptions
        {
            WriteIndented = true
        }));

        using IServiceScope scope = _serviceProvider.CreateScope();

        if (message is TaskCreatedEvent taskCreatedEvent)
        {
            var handler = scope.ServiceProvider
                .GetRequiredService<IIntegrationEventHandler<TaskCreatedEvent>>();

            await handler.HandleAsync(taskCreatedEvent);
        }

        return;
    }
}
