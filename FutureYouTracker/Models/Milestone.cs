namespace FutureYouTracker.Models;

public class Milestone
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? CompletedDate { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}