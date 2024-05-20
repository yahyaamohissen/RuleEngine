using Elsa.ActivityResults;
using Elsa.Attributes;
using Elsa.Services;
using Elsa.Services.Models;
using RuleEngine.ELSA.Web.Models;

namespace RuleEngine.ELSA.Web.Activities.DepotFilters
{
    [Activity(Category = "Depot Rules", Description = "This is one of the depot rules engine.", DisplayName = "Filter B&Q depots")]
    public class FilterBAndQDpotsActivity: Activity, IActivityContract
    {
        [ActivityInput(Hint = "Number of lines to be added, if not provided will be random.", Name ="Test bool")]
        public bool NumberOfLines { get; set; }

        private readonly TextWriter writer;

        public FilterBAndQDpotsActivity(TextWriter writer)
        {
            this.writer = writer;
        }

        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext  context)
        {
            var previousActivityResult = (List<Depot>)context.Input ?? new List<Depot>();

            writer.WriteLine("************number is*************" + previousActivityResult.Count);

            return Done(previousActivityResult);
        }
    }
}