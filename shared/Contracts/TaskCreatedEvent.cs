namespace Contracts;

public class TaskCreatedEvent : IIntegrationEvent
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
