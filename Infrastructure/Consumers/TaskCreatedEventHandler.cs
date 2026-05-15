using Contracts;
using Microsoft.Extensions.Logging;

namespace Consumers;

public class TaskCreatedEventHandler
    : IIntegrationEventHandler<TaskCreatedEvent>
{
    private readonly ILogger<TaskCreatedEventHandler> _logger;

    public TaskCreatedEventHandler(ILogger<TaskCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public async Task HandleAsync(TaskCreatedEvent taskCreatedEvent)
    {
        _logger.LogInformation(
            "Task created event consumed: {TaskTitle}",
            taskCreatedEvent.Title);
    }
}
