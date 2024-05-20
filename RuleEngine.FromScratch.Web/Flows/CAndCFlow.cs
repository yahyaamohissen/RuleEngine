using RuleEngine.FromScratch.Web.Activities;
using RuleEngine.FromScratch.Web.Models;

namespace RuleEngine.FromScratch.Web.Flows
{
    public class CAndCFlow : FlowBase
    {
        //public FlowContext Context {  get; private set; }

        //public IList<IActivity> Activities { get; private set; }

        //public IActivity CurrentActivity { get; private set; }



        //public FlowExcecutionResult Fire()
        //{
        //    throw new NotImplementedException();
        //}

        //public ValueTask<FlowExcecutionResult> FireAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public FlowExcecutionResult Terminate()
        //{
        //    throw new NotImplementedException();
        //}

        public CAndCFlow()
            :base(new FlowContext())
        {
            
        } 

        public override FlowExcecutionResult Fire()
        {
            throw new NotImplementedException();
        }

        public override ValueTask<FlowExcecutionResult> FireAsync()
        {
            throw new NotImplementedException();
        }

        public override FlowExcecutionResult Terminate()
        {
            throw new NotImplementedException();
        }
    }
}
