using Elsa.ActivityResults;
using Elsa.Attributes;
using Elsa.Services;
using Elsa.Services.Models;
using System.ComponentModel.DataAnnotations;

namespace RuleEngine.ELSA.Web.Activities.DepotFilters
{
    [Activity(Category = "Depot Rules", Description = "This is one of the depot rules engine.", DisplayName = "Trim and order List ")]
    public class TrimAndOrderActivity: Activity, IActivityContract
    {
        [Required]
        [ActivityInput(Hint = "Number of depots to be returned.", Name = "Max number of depots to be returned")]
        public int MaxNumberOfDepots { get; set; }

        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
            return Done();
        }
    }
}