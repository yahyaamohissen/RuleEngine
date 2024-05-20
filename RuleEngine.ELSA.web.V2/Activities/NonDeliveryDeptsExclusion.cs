using Elsa.ActivityResults;
using Elsa.Attributes;
using Elsa.Services;
using Elsa.Services.Models;
using RuleEngine.ELSA.web.V2.Models;

namespace RuleEngine.ELSA.web.V2.Activities
{
    [Activity(Category = "Depot Rules", Description = "Filter out all not Delivery Depts", DisplayName = "Non-Delivery Depts Exclusion")]
    public class NonDeliveryDeptsExclusion: Activity 
    {
        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
            var depots = (IEnumerable<Depot>)context.WorkflowExecutionContext.GetVariable("depots") ?? new List<Depot>();

            var allDeliveryDepots = depots.Where(depot => depot.IsDelivery == true);

            context.SetVariable("depots", allDeliveryDepots);

            return Done();
        }
    }
}