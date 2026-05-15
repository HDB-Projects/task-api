using System.Text.Json;
using Contracts;
using Consumers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Messaging;

public class FakeMessageBus : IMessageBus
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<FakeMessageBus> _logger;

    public FakeMessageBus(IServiceProvider serviceProvider, ILogger<FakeMessageBus> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }
    public async Task PublishAsync(IIntegrationEvent message)
    {
        _logger.LogInformation(
            "Event published: {EventType}",
            message.GetType().Name);
        
        _logger.LogDebug(
            "Event payload: {Payload}",
            JsonSerializer.Serialize(message));

        using IServiceScope scope = _serviceProvider.CreateScope();

        if (message is TaskCreatedEvent taskCreatedEvent)
        {
            var handler = scope.ServiceProvider
                .GetRequiredService<IIntegrationEventHandler<TaskCreatedEvent>>();

            await handler.HandleAsync(taskCreatedEvent);
        }
    }
}
