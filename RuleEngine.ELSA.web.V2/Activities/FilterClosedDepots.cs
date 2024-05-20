using Elsa.Services;
using Elsa.Attributes;
using Elsa.ActivityResults;
using Elsa.Services.Models;
using RuleEngine.ELSA.web.V2.Models;

namespace RuleEngine.ELSA.web.V2.Activities
{
    [Activity(Category = "Depot Rules", Description = "Filter out all closed depots", DisplayName = "Filter closed depots")]
    public class FilterClosedDepots : Activity 
    {
        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
            var depots = (IEnumerable<Depot>)context.WorkflowExecutionContext.GetVariable("depots") ?? new List<Depot>();

            var openDepots = depots.Where(depot => depot.IsOpen == true);

            context.SetVariable("depots", openDepots);

            return Done();
        }
    }
}