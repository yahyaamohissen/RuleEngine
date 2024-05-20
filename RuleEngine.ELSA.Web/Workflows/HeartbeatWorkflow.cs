using Elsa.Activities.Console;
using Elsa.Activities.ControlFlow;
using Elsa.Activities.Temporal;
using Elsa.Builders;
using Elsa.Models;
using NodaTime;
using RuleEngine.ELSA.Web.Activities.DepotFilters;

namespace RuleEngine.ELSA.Web.Workflows
{
    public class HeartbeatWorkflow : IWorkflow
    {
        private readonly IClock clock;

        public HeartbeatWorkflow(IClock clock)
        {
            this.clock = clock;
        }

        public void Build(IWorkflowBuilder builder)
        {
            var wf = builder
                .Timer(Duration.FromMinutes(1))
                .WithDisplayName("from code timer")
                .WriteLine(context => $"Heartbeat at {clock.GetCurrentInstant()}")
                .IfTrue(() => { return true; }, builderr => builderr.Then<GetDepotsFromWHActivity>().Then<FilterBAndQDpotsActivity>())
                
                .IfFalse(() => { return true; }, builderr => builderr.Then<FilterBAndQDpotsActivity>())
                .If(() => { return true; },
                        whenTrue: builderr => builderr.Then<GetDepotsFromWHActivity>()
                                                .If(()=>true, whenTrue: bulder => bulder.WriteLine("Inner most if true"), 
                                                        whenFalse: b=>b.WriteLine("Inner most if false"))
                                                            .WriteLine("innermost if done")
                                                            .WithName("inner if done"),
                        whenFalse: b => b.Then<TrimAndOrderActivity>())
                .WriteLine("End");

        }
    }
}