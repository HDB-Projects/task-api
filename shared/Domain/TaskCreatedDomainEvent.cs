namespace Domain;

public class TaskCreatedDomainEvent : DomainEvent
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
}
