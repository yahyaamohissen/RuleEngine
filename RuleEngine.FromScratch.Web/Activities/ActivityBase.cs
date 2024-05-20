using RuleEngine.FromScratch.Web.Models;

namespace RuleEngine.FromScratch.Web.Activities
{
    public abstract class ActivityBase : IActivity // to remove interface 
    {
        public abstract int Order { get; set; }

        public abstract Type? Next { get; protected set; }

        public abstract Func<ActivityContext, bool> NextIf { get; protected set; }

        public ActivityExcecutionResult ExecuteFlow()
        {
            
        }

        public async ValueTask<ActivityExcecutionResult> ExecuteFlowAsync()
        {

        }


        public abstract ActivityExcecutionResult Execute(ActivityContext context);

        public abstract ValueTask<ActivityExcecutionResult> ExecuteAsync(ActivityContext context);

        public virtual ActivityExcecutionResult Skip(ActivityContext context)
        {

        }
    }
}