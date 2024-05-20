// See https://aka.ms/new-console-template for more information
//using RulesEngine.Models;

using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using RulesEngine.Extensions;
using RulesEngine.Models;
using System.Dynamic;
using RuleEngine.Microsoft.EF;

Console.WriteLine("Hello, i have started!");


//var rulesEngine = new RulesEngine.RulesEngine();

//List<Rule> rules = new List<Rule>();

//Rule rule = new Rule();
//rule.RuleName = "Test Rule";
//rule.SuccessEvent = "Count is within tolerance.";
//rule.ErrorMessage = "Over expected.";
//rule.Expression = "count < 3";
//rule.RuleExpressionType = RuleExpressionType.LambdaExpression;
//rules.Add(rule);

//var workflows = new List<Workflow>();

//Workflow exampleWorkflow = new Workflow();
//exampleWorkflow.WorkflowName = "Example Workflow";
//exampleWorkflow.Rules = rules;

//workflows.Add(exampleWorkflow);

//var rulesEngine = new RulesEngine.RulesEngine(workflows.ToArray());

//Console.WriteLine($"Running {nameof(JSONDemo)}....");


//var basicInfo = "{\"name\": \"hello\",\"email\": \"abcy@xyz.com\",\"creditHistory\": \"good\",\"country\": \"canada\",\"loyaltyFactor\": 3,\"totalPurchasesToDate\": 10000}";
//var orderInfo = "{\"totalOrders\": 5,\"recurringItems\": 2}";
//var telemetryInfo = "{\"noOfVisitsPerMonth\": 10,\"percentageOfBuyingToVisit\": 15}";

//var converter = new ExpandoObjectConverter();

//dynamic input1 = JsonConvert.DeserializeObject<ExpandoObject>(basicInfo, converter);
//dynamic input2 = JsonConvert.DeserializeObject<ExpandoObject>(orderInfo, converter);
//dynamic input3 = JsonConvert.DeserializeObject<ExpandoObject>(telemetryInfo, converter);

//var inputs = new dynamic[]
//    {
//                    input1,
//                    input2,
//                    input3
//    };

var input = new DiscountRulesInput()
{
    BasicInfo = new BasicInfo { Name = "hello", Email = "abcy@xyz.com", CreditHistory = "good", Country = "canada", LoyaltyFactor = 3, TotalPurchasesToDate = 10000 },
    OrderInfo = new OrderInfo { RecurringItems = 2, TotalOrders = 5 },
    TelemetryInfo = new TelemetryInfo { NoOfVisitsPerMonth = 10, PercentageOfBuyingToVisit = 15 }
};

var data = new dynamic[] { input };


var files = Directory.GetFiles(Directory.GetCurrentDirectory(), "Discount.json", SearchOption.AllDirectories);
//var isThere.if(()). = File.Exists("Discount.json");

if (files == null || files.Length == 0)
    throw new Exception("Rules not found.");

var fileData = File.ReadAllText(files[0]);
var workflow = JsonConvert.DeserializeObject<List<Workflow>>(fileData);

var bre = new RulesEngine.RulesEngine(workflow.ToArray(), null);

string discountOffered = "No discount offered.";

List<RuleResultTree> resultList = bre.ExecuteAllRulesAsync("Discount", data).Result;

resultList.OnSuccess((eventResult) => {
    var discount = JsonConvert.DeserializeObject<DiscountInfo>(eventResult);
    input.DiscountInfo = discount;
    Console.WriteLine("--- Dicount selected ---\t" + discount.Amount.ToString());
});

resultList.OnFail(() => {
    discountOffered = "The user is not eligible for any discount.";
});

Console.WriteLine(discountOffered);



