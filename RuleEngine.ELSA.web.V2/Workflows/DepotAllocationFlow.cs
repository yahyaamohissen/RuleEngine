using Elsa;
using Elsa.Activities.ControlFlow;
using Elsa.Activities.Http;
using Elsa.Activities.Http.Models;
using Elsa.Builders;
using Elsa.Services.Models;
using Newtonsoft.Json;
using RuleEngine.ELSA.web.V2.Activities;
using RuleEngine.ELSA.web.V2.Models;
using System.Net;

namespace RuleEngine.ELSA.web.V2.Workflows
{
    public class DepotAllocationFlow : IWorkflow
    {
        public void Build(IWorkflowBuilder builder)
        {
            builder.HttpEndpoint(httpOptions =>
            {
                httpOptions.WithPath("test");
                httpOptions.WithMethod("GET");
            }).When(OutcomeNames.Done)

            .Then<GetDepots>().WithName("GetDepots").WithDisplayName("Get depots from WH").When(OutcomeNames.Done)

            .If(condition: IsClickAndCollectRequest, 
                whenTrue: outcomeBuilder => outcomeBuilder.Then<NonClickAndCollectExclusion>()
                                                        .Then<FilterClosedDepots>(),
                whenFalse: outcomeBuilder => outcomeBuilder.Then<NonDeliveryDeptsExclusion>()).WithName("IsClickAndCollectCheck").WithDisplayName("Check if it is a C&C.")//.When(OutcomeNames.Done)

            .If(condition: IsBeforLeadTime, 
                whenTrue: outcomeBuilder => outcomeBuilder.Then<StockCheck>(),
                whenFalse: outcomeBuilder => outcomeBuilder.Then<CapabilityCheck>()).WithName("IsBeforLeadTime").WithDisplayName("Is Befor Lead Time")//.When(OutcomeNames.Done)

            .Then<SortDepots>().When(OutcomeNames.Done)

            .WriteHttpResponse(
                statusCode: (_) => HttpStatusCode.OK,
                content: ResponseResolver,
                contentType: (_) => "application/json"
                );
        }

        public bool IsClickAndCollectRequest(ActivityExecutionContext activityExeContext)
        {
            var request = (HttpRequestModel)activityExeContext.Input;

            return Boolean.Parse(request.QueryString["iscandc"]);
        }
        
        public bool IsBeforLeadTime(ActivityExecutionContext activityExeContext)
        {
            var request = (HttpRequestModel)activityExeContext.Input;

            return Boolean.Parse(request.QueryString["isbefore"]);
        }

        public string ResponseResolver(ActivityExecutionContext activityExeContext)
        {
            var depots = (IEnumerable<Depot>)activityExeContext.WorkflowExecutionContext.GetVariable("depots") ?? new List<Depot>();
            return JsonConvert.SerializeObject(depots);
        }
    }
}