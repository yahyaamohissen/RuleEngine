using RuleEngine.FromScratch.Web.Activities;
using RuleEngine.FromScratch.Web.Models;

namespace RuleEngine.FromScratch.Web.Flows
{
    public abstract class FlowBase
    {
        protected FlowContext Context { get; private set; }
        protected IList<IActivity> Activities { get; set; }
        protected IActivity CurrentActivity { get; private set; }

        public FlowBase(FlowContext context)
        {
            this.Context = context;
        }

        public abstract FlowExcecutionResult Fire();
        public abstract ValueTask<FlowExcecutionResult> FireAsync();
        public abstract FlowExcecutionResult Terminate();

        public sealed bool SetCurrentActivity(IActivity activity)
        {
            if (Activities.Contains(activity))
                CurrentActivity = activity;
            for (int i = 0; i < Activities; i++)
            {

            } 
        }
    }
}