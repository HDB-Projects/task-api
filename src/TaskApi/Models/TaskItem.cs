namespace TaskApi.Models;

public class TaskItem
{
    public Guid Id { get; set; }
    
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string Status { get; set; } = "Open";

    public DateTime CreatedAt { get; set;} = DateTime.UtcNow;
}
