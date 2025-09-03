using FutureYouTracker.Models;

namespace FutureYouTracker.Services;

public class TargetService : ITargetService
{
    private readonly ILocalStorageService _localStorage;
    private const string StorageKey = "futureyou_targets";

    public TargetService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<List<Target>> GetAllTargetsAsync()
    {
        var targets = await _localStorage.GetItemAsync<List<Target>>(StorageKey);
        return targets ?? new List<Target>();
    }

    public async Task<Target?> GetTargetByIdAsync(Guid id)
    {
        var targets = await GetAllTargetsAsync();
        return targets.FirstOrDefault(t => t.Id == id);
    }

    public async Task<Target> CreateTargetAsync(Target target)
    {
        var targets = await GetAllTargetsAsync();
        target.Id = Guid.NewGuid();
        target.CreatedDate = DateTime.UtcNow;
        targets.Add(target);
        await _localStorage.SetItemAsync(StorageKey, targets);
        return target;
    }

    public async Task<Target> UpdateTargetAsync(Target target)
    {
        var targets = await GetAllTargetsAsync();
        var index = targets.FindIndex(t => t.Id == target.Id);
        if (index >= 0)
        {
            targets[index] = target;
            await _localStorage.SetItemAsync(StorageKey, targets);
        }
        return target;
    }

    public async Task<bool> DeleteTargetAsync(Guid id)
    {
        var targets = await GetAllTargetsAsync();
        var target = targets.FirstOrDefault(t => t.Id == id);
        if (target != null)
        {
            targets.Remove(target);
            await _localStorage.SetItemAsync(StorageKey, targets);
            return true;
        }
        return false;
    }

    public async Task<List<Target>> GetTargetsByCategoryAsync(TargetCategory category)
    {
        var targets = await GetAllTargetsAsync();
        return targets.Where(t => t.Category == category).ToList();
    }

    public async Task<List<Target>> GetTargetsByPriorityAsync(Priority priority)
    {
        var targets = await GetAllTargetsAsync();
        return targets.Where(t => t.Priority == priority).ToList();
    }

    public async Task<List<Target>> GetOverdueTargetsAsync()
    {
        var targets = await GetAllTargetsAsync();
        return targets.Where(t => t.IsOverdue).ToList();
    }

    public async Task<List<Target>> GetCompletedTargetsAsync()
    {
        var targets = await GetAllTargetsAsync();
        return targets.Where(t => t.IsCompleted).ToList();
    }

    public async Task<bool> CompleteTargetAsync(Guid id)
    {
        var targets = await GetAllTargetsAsync();
        var target = targets.FirstOrDefault(t => t.Id == id);
        if (target != null)
        {
            target.IsCompleted = true;
            target.CompletedDate = DateTime.UtcNow;
            await _localStorage.SetItemAsync(StorageKey, targets);
            return true;
        }
        return false;
    }

    public async Task<bool> ToggleMilestoneAsync(Guid targetId, Guid milestoneId)
    {
        var targets = await GetAllTargetsAsync();
        var target = targets.FirstOrDefault(t => t.Id == targetId);
        if (target != null)
        {
            var milestone = target.Milestones.FirstOrDefault(m => m.Id == milestoneId);
            if (milestone != null)
            {
                milestone.IsCompleted = !milestone.IsCompleted;
                milestone.CompletedDate = milestone.IsCompleted ? DateTime.UtcNow : null;
                await _localStorage.SetItemAsync(StorageKey, targets);
                return true;
            }
        }
        return false;
    }
}