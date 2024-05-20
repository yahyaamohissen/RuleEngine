using Elsa;
using Elsa.Activities.Http;
using Elsa.Builders;
using System.Net;

namespace RuleEngine.ELSA.Web.Workflows
{
    public class MyFirstHttpFlow : IWorkflow
    {
        public void Build(IWorkflowBuilder builder)
        {
            builder.HttpEndpoint(s => {
                s.WithPath("/test-hi");
                s.WithMethod("GET");
            })
                .When(OutcomeNames.Done)
                .WriteHttpResponse(HttpStatusCode.OK, "<h1>Hello World from ELSA!</h1>", "text/html");

        }
    }
}