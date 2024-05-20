using Elsa;
using Elsa.Activities.Http;
using Elsa.Builders;
using System.Linq.Expressions;
using System.Net;

namespace RuleEngine.ELSA
{
    public class RulesWorkflow : IWorkflow
    {
        public void Build(IWorkflowBuilder builder)
        {
            builder.HttpEndpoint("/test-rules")
                .When(OutcomeNames.Done)
                .WriteHttpResponse(HttpStatusCode.OK, "<h1>Hello World!</h1>", "text/html");
        }

        
    }
}