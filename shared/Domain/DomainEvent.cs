namespace Domain;

public abstract class DomainEvent
{
    public DateTime OccuredOn { get; set; } = DateTime.UtcNow;
}
