using Domain;

namespace TaskApi.Models;

public class TaskItem : IHasDomainEvents
{
    public Guid Id { get; set; }
    
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string Status { get; set; } = "Open";

    public DateTime CreatedAt { get; set;} = DateTime.UtcNow;

    private readonly List<DomainEvent> _domainEvents = new List<DomainEvent>();

    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents;

    public void AddDomainEvent(DomainEvent eventItem)
    {
        _domainEvents.Add(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public static TaskItem Create(CreateTaskDto taskDto)
    {
        TaskItem taskItem = new TaskItem
        {
            Id = Guid.NewGuid(),
            Title = taskDto.Title,
            Description = taskDto.Description
        };

        taskItem.AddDomainEvent(new TaskCreatedDomainEvent
        {
            Id = taskItem.Id,
            Title = taskItem.Title,
            OccuredOn = taskItem.CreatedAt
        });

        return taskItem;
    }
}
