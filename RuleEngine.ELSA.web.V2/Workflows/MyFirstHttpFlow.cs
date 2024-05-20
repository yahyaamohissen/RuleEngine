using Elsa.Activities.Http;
using Elsa.Builders;
using System.Net;

namespace RuleEngine.ELSA.web.V2.Workflows
{
    public class MyFirstHttpFlow: IWorkflow
    {
        public void Build(IWorkflowBuilder builder)
        {
            builder
                .HttpEndpoint("/hello-world")
                .WriteHttpResponse(HttpStatusCode.OK, "<h1>Hello World!</h1>", "text/html");
        }
    }
}
