using NRules.Fluent.Dsl;

namespace RuleEngine
{
    public class RuleTemplate2 : Rule
    {
        public class RuleTemplate2Object1
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool IsApproved { get; set; } = false;
            public bool AnotherCondition { get; set; } = true;

            public string ValidationText { get; set; } = "";

            public void FillValidationText()
            {
                Console.WriteLine($"HELLO {Name}");
                Name = $"HELLO {Name}";
                ValidationText = "tested";
            }
        }


        public override void Define()
        {
            RuleTemplate2Object1 input = default;

            When().Match<RuleTemplate2Object1>(() => input, o => o.IsApproved);

            Then()
                .Do(c => input.FillValidationText());
                //.Do(c => c.Update(input));
        }
    }
}