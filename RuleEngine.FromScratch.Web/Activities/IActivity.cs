using RuleEngine.FromScratch.Web.Models;

namespace RuleEngine.FromScratch.Web.Activities
{
    public interface IActivity
    {
        int Order { get; }
        Guid Id { get; }

        ValueTask<ActivityExcecutionResult> ExecuteAsync(ActivityContext context);
        ActivityExcecutionResult Execute(ActivityContext context);
        ActivityExcecutionResult Skip(ActivityContext context);
    }
}