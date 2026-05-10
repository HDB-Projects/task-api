using Contracts;

namespace Consumers;

public class TaskCreatedEventHandler
    : IIntegrationEventHandler<TaskCreatedEvent>
{
    public async Task HandleAsync(TaskCreatedEvent taskCreatedEvent)
    {
        Console.WriteLine("=== EVENT CONSUMED ===");
        Console.WriteLine($"Task created: {taskCreatedEvent.Title}");

        return;
    }
}
