// See https://aka.ms/new-console-template for more information
using Elsa.Services;
using Microsoft.Extensions.DependencyInjection;
using RuleEngine.ELSA;

Console.WriteLine("Hello, World!");


var services = new ServiceCollection()
                .AddElsa(options => options
                    .AddConsoleActivities()
                    .AddWorkflow<RulesWorkflow>())
                .BuildServiceProvider();

// Get a workflow runner.
var workflowRunner = services.GetRequiredService<IBuildsAndStartsWorkflow>();

// Run the workflow.
await workflowRunner.BuildAndStartWorkflowAsync<RulesWorkflow>();