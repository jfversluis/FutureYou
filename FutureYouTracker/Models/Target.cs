using System.ComponentModel.DataAnnotations;

namespace FutureYouTracker.Models;

public class Target
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Title is required")]
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
    public string Title { get; set; } = string.Empty;

    [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Category is required")]
    public TargetCategory Category { get; set; } = TargetCategory.Personal;

    [Required(ErrorMessage = "Priority is required")]
    public Priority Priority { get; set; } = Priority.Medium;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public DateTime? DueDate { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime? CompletedDate { get; set; }

    public List<Milestone> Milestones { get; set; } = new();

    [StringLength(200, ErrorMessage = "Tags cannot exceed 200 characters")]
    public string Tags { get; set; } = string.Empty;

    // SMART Goal Framework Properties
    [StringLength(500, ErrorMessage = "Specific details cannot exceed 500 characters")]
    public string Specific { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Measurable criteria cannot exceed 500 characters")]
    public string Measurable { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Achievable details cannot exceed 500 characters")]
    public string Achievable { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Relevant details cannot exceed 500 characters")]
    public string Relevant { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Time-bound details cannot exceed 500 characters")]
    public string TimeBound { get; set; } = string.Empty;

    // Helper properties
    public bool IsOverdue => DueDate.HasValue && DueDate.Value < DateTime.Now && !IsCompleted;
    
    public int DaysUntilDue
    {
        get
        {
            if (!DueDate.HasValue) return int.MaxValue;
            return (int)(DueDate.Value - DateTime.Now).TotalDays;
        }
    }

    public double CompletionPercentage
    {
        get
        {
            if (IsCompleted) return 100.0;
            if (Milestones.Count == 0) return 0.0;
            
            var completedMilestones = Milestones.Count(m => m.IsCompleted);
            return (double)completedMilestones / Milestones.Count * 100.0;
        }
    }

    public List<string> GetTagList()
    {
        return Tags.Split(',', StringSplitOptions.RemoveEmptyEntries)
                  .Select(tag => tag.Trim())
                  .Where(tag => !string.IsNullOrEmpty(tag))
                  .ToList();
    }

    public void SetTags(IEnumerable<string> tags)
    {
        Tags = string.Join(", ", tags.Where(tag => !string.IsNullOrWhiteSpace(tag)));
    }
}