using Microsoft.EntityFrameworkCore;
using RuleEngine.ELSA.web.V2.Models;

namespace RuleEngine.ELSA.web.V2
{
    public class AppDBContext: DbContext 
    {
        public AppDBContext()//: base("")
        {
                
        }
        public DbSet<Depot> Depots { get; set; }
    }
}
