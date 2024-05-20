using Elsa.ActivityResults;
using Elsa.Attributes;
using Elsa.Services;
using Elsa.Services.Models;

namespace RuleEngine.ELSA.Web.Activities.DepotFilters
{
    [Activity(Category = "Depot Rules", Description = "This is one of the depot rules engine.", DisplayName = "Filter collcetion depots")]
    public class CollectionRestictionsFilterActivity: Activity, IActivityContract
    {
        [ActivityInput(Hint = "Number of lines to be added, if not provided will be random.", Name = "IsCollectionAvailable")]
        public bool IsCollectionAvailable { get; set; }

        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
            return Done();
        }
    }
}
