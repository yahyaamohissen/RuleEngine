using Elsa.ActivityResults;
using Elsa.Attributes;
using Elsa.Services;
using Elsa.Services.Models;
using RuleEngine.ELSA.web.V2.Models;
using System.ComponentModel.DataAnnotations;

namespace RuleEngine.ELSA.web.V2.Activities
{
    public enum SortBy { 
        Distance = 1,
        Id = 2
    }


    [Activity(Category = "Depot Rules", Description = "Sort depots", DisplayName = "Sort depots")]
    public class SortDepots: Activity 
    {
        [Required]
        [ActivityInput(Hint = "Sort By", Name = "Sort By")]
        public SortBy SortBy { get; set; }

        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
            var depots = (IEnumerable<Depot>)context.WorkflowExecutionContext.GetVariable("depots") ?? new List<Depot>();
            depots.OrderBy(depot => depot.DepotName);
            context.SetVariable("depots", depots);
            return Done();
        }
    }
}