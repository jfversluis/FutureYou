namespace FutureYouTracker.Models;

public enum Priority
{
    Low,
    Medium,
    High,
    Urgent
}

public static class PriorityExtensions
{
    public static string GetDisplayName(this Priority priority)
    {
        return priority switch
        {
            Priority.Low => "🟢 Low Priority",
            Priority.Medium => "🟡 Medium Priority",
            Priority.High => "🟠 High Priority",
            Priority.Urgent => "🔴 Urgent",
            _ => priority.ToString()
        };
    }

    public static string GetIcon(this Priority priority)
    {
        return priority switch
        {
            Priority.Low => "🟢",
            Priority.Medium => "🟡",
            Priority.High => "🟠",
            Priority.Urgent => "🔴",
            _ => "⚪"
        };
    }

    public static string GetColorClass(this Priority priority)
    {
        return priority switch
        {
            Priority.Low => "priority-low",
            Priority.Medium => "priority-medium",
            Priority.High => "priority-high",
            Priority.Urgent => "priority-urgent",
            _ => "priority-default"
        };
    }
}