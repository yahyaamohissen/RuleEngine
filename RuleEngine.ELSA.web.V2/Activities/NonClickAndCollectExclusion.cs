using Elsa.ActivityResults;
using Elsa.Attributes;
using Elsa.Services;
using Elsa.Services.Models;
using RuleEngine.ELSA.web.V2.Models;

namespace RuleEngine.ELSA.web.V2.Activities
{
    [Activity(Category = "Depot Rules", Description = "Filter out all closed depots", DisplayName = "Filter closed depots")]
    public class NonClickAndCollectExclusion: Activity 
    {
        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
            var depots = (IEnumerable<Depot>)context.WorkflowExecutionContext.GetVariable("depots") ?? new List<Depot>();

            var allCAndCDepots = depots.Where(depot => depot.IsClickAndCollect == true);

            context.SetVariable("depots", allCAndCDepots);

            return Done();
        }
    }
}