using NRules.Fluent.Dsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine
{
    public class RuleTemplate1Object1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsApproved { get; set; } = false;
    }

    public class RuleTemplate1Object2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsWellcomed { get; set; } = false;
        public List<RuleTemplate1Object1> RuleTemplate1Object1s { get; set; }

        public void SayHello()
        {
            IsWellcomed = true;
            Console.WriteLine($"HELLO {Name}");
            Name = $"HELLO {Name}";
        }
    }

    public class RuleTemplate1 : Rule
    {

        public bool isWelcomed(RuleTemplate1Object2 obj)
        {
            var res = !obj.IsWellcomed;
            return res;
        }

        public override void Define()
        {
            RuleTemplate1Object2? object2dot1 = default;
            //IEnumerable<RuleTemplate1Object1>? objects1 = default;
            When()
                .Match<RuleTemplate1Object2>(() => object2dot1, o => !o.IsWellcomed);
            //.Query<IEnumerable<RuleTemplate1Object1>>(() => objects1, q => 
            //    q.Match<RuleTemplate1Object1>(
            //        o => o.IsApproved)
            //    .Collect()
            //    .Where(c => c.Any())
            //);


            Then()
                .Do(context => object2dot1.SayHello())
                .Do(context => context.Update(object2dot1));

                //.Query<IEnumerable<RuleTemplate1Object1>>(() => objects1, 
                //    q=> q.Match<IEnumerable<RuleTemplate1Object1>>(list=> list.All(o=> o.IsApproved))
                //    .Collect()
                //)
                //.
        }
    }
}
