using Elsa.ActivityResults;
using Elsa.Attributes;
using Elsa.Services;
using Elsa.Services.Models;

namespace RuleEngine.ELSA.Web.Activities.DepotFilters
{
    [Activity(Category = "Depot Rules", Description = "This is one of the depot rules engine.", DisplayName = "Filter closed depots")]
    public class ClosedDepotsFilterActivity: Activity, IActivityContract
    {
        private readonly TextWriter writer;

        public ClosedDepotsFilterActivity(TextWriter writer)
        {
            this.writer = writer;
        }

        [ActivityInput(Hint = "Number of lines to be added, if not provided will be random.")]
        public int? NumberOfLines { get; set; }

        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
            if (NumberOfLines == null || NumberOfLines == 0)
                NumberOfLines = new Random().Next(1, 20);

            for (int i = 0; i < NumberOfLines; i++)
            {
                writer.WriteLine($"{i}\tHi from custom.");
            }

            return Done();
        }
    }
}