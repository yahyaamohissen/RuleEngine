using Elsa.ActivityResults;
using Elsa.Attributes;
using Elsa.Services;
using Elsa.Services.Models;

namespace RuleEngine.ELSA.Web.Activities
{
    [Activity(Category = "Custom", Description = "This is my first custom activity.", DisplayName ="First custom activity")]
    public class MyFirstCustomActivity: Activity, IActivityContract
    {
        private readonly TextWriter writer;

        public MyFirstCustomActivity(TextWriter writer)
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