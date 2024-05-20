// See https://aka.ms/new-console-template for more information

using NRules;
using NRules.Fluent;
using RuleEngine;
using static RuleEngine.RuleTemplate2;

Console.WriteLine("Hello, World!, I have started.");


var repository = new RuleRepository();
repository.Load(x => x.From(typeof(RuleTemplate1).Assembly));

//Compile rules
var factory = repository.Compile();

//Create a working session
var session = factory.CreateSession();

var object1 = new RuleTemplate1Object2 { Name = "Object 1", Id = 1, IsWellcomed = true };
var object2 = new RuleTemplate1Object2 { Name = "Object 2", Id = 2, IsWellcomed = false };
var object3 = new RuleTemplate1Object2 { Name = "Object 3", Id = 1, IsWellcomed = false };
var object4 = new RuleTemplate1Object2 { Name = "Object 4", Id = 1, IsWellcomed = true };



var object21 = new RuleTemplate2Object1 { Name = "21", IsApproved = true };
var object22 = new RuleTemplate2Object1 { Name = "21", IsApproved = false };
var object23 = new RuleTemplate2Object1 { Name = "21", IsApproved = false };
var object24 = new RuleTemplate2Object1 { Name = "hyhyhyhy", IsApproved = true };

Console.WriteLine("Hello, World!, I have created suss'.");

session.Insert(object1);
session.Insert(object2);
session.Insert(object4);
session.Insert(object3);


session.Insert(object21);
session.Insert(object22);
session.Insert(object24);
session.Insert(object23);

session.Fire();



Console.WriteLine("Hello, World!, I have finished.");