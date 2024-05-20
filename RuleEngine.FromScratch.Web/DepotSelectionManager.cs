using RuleEngine.FromScratch.Web.Flows;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RuleEngine.FromScratch.Web
{
    public class DepotResult { 
    }
    
    public class DepotRequest { 
    }

    public class DepotSelectionManager
    {
        public static List<Type> Flows;

        public DepotSelectionManager()
        {
        }

        static DepotSelectionManager()
        {
            Flows = new List<Type>();
        }

        public IEnumerable<DepotResult> GetDepots(DepotRequest request)
        {
            var flowResult = flows.FirstOrDefault(flow => true)?.Fire();
            return new List<DepotResult>();
        }

        public async ValueTask<IEnumerable<DepotResult>> GetDepotsAsync(DepotRequest request)
        {
            var flowResult = await flows.FirstOrDefault(flow => true).FireAsync();
            return new List<DepotResult>();
        }
    }
}