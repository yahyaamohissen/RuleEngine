using Elsa.ActivityResults;
using Elsa.Attributes;
using Elsa.Services;
using Elsa.Services.Models;
using RuleEngine.ELSA.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace RuleEngine.ELSA.Web.Activities.DepotFilters
{
    [Activity(Category = "Depot Rules", Description = "This is one of the depot rules engine. this should be the first one", DisplayName = "Get list of depots")]
    public class GetDepotsFromWHActivity : Activity, IActivityContract
    {
        [Required]
        [ActivityInput(Hint = "Number of lines to be added, if not provided will be random.", Name = "Max Number Of Depots to be returned")]
        public int MaxNumberOfDepots { get; set; }

        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
            var depots = new List<Depot> {
            new Depot{
                Id = 1,
                IsClosed = false,
                IsCollection = false,
                Name = "Hi 1"
            },
            new Depot{
                Id = 2,
                IsClosed = true,
                IsCollection = true,
                Name = "Hi 2"
            },
            new Depot{
                Id = 3,
                IsClosed = false,
                IsCollection = true,
                Name = "Hi 3"
            },
            new Depot{
                Id = 4,
                IsClosed = false,
                IsCollection = true,
                Name = "Hi 4"
            },
            new Depot{
                Id = 5,
                IsClosed = true,
                IsCollection = true,
                Name = "Hi 5"
            },
            new Depot{
                Id = 6,
                IsClosed = false,
                IsCollection = true,
                Name = "Hi 6"
            },
            new Depot{
                Id = 7,
                IsClosed = false,
                IsCollection = true,
                Name = "Hi 7"
            },
            new Depot{
                Id = 8,
                IsClosed = false,
                IsCollection = true,
                Name = "Hi 8"
            },
            };


            return Done(depots);
        }
    }
}