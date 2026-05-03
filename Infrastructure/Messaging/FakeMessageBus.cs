using System.Text.Json;
using Contracts;

namespace Infrastructure.Messaging;

public class FakeMessageBus : IMessageBus
{
    public Task PublishAsync(IIntegrationEvent message)
    {
        Console.WriteLine("=== EVENT PUBLISHED ===");
        Console.WriteLine(JsonSerializer.Serialize(message, message!.GetType(), new JsonSerializerOptions
        {
            WriteIndented = true
        }));

        return Task.CompletedTask;
    }
}
