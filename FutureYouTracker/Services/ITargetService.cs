using FutureYouTracker.Models;

namespace FutureYouTracker.Services;

public interface ITargetService
{
    Task<List<Target>> GetAllTargetsAsync();
    Task<Target?> GetTargetByIdAsync(Guid id);
    Task<Target> CreateTargetAsync(Target target);
    Task<Target> UpdateTargetAsync(Target target);
    Task<bool> DeleteTargetAsync(Guid id);
    Task<List<Target>> GetTargetsByCategoryAsync(TargetCategory category);
    Task<List<Target>> GetTargetsByPriorityAsync(Priority priority);
    Task<List<Target>> GetOverdueTargetsAsync();
    Task<List<Target>> GetCompletedTargetsAsync();
    Task<bool> CompleteTargetAsync(Guid id);
    Task<bool> ToggleMilestoneAsync(Guid targetId, Guid milestoneId);
}