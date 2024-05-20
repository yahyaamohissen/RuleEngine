using Elsa.Activities.Http.Models;
using Elsa.ActivityResults;
using Elsa.Attributes;
using Elsa.Services;
using Elsa.Services.Models;
using RuleEngine.ELSA.web.V2.Models;
using System.Data.SqlClient;

namespace RuleEngine.ELSA.web.V2.Activities
{
    [Activity(Category = "Depot Rules", Description = "Doing stock check on the products", DisplayName = "Stock check.")]
    public class StockCheck : Activity 
    {
        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
            var connectionString = "Server=tcp:sppedyserver.database.windows.net,1433;Initial Catalog=DepotAllocation;Persist Security Info=False;User ID=Nidal;Password=Momani@1992;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            string SQL = "[dbo].[usp_getStockAvailbilty]";

            var availableDepotCodes = new List<string>();
            var allDepots = (IEnumerable<Depot>)context.WorkflowExecutionContext.GetVariable("depots") ?? new List<Depot>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    var httpRequest = (HttpRequestModel)context.Input;
                    connection.Open();

                    SqlCommand command = new SqlCommand(SQL, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@p_productCode", httpRequest.QueryString["productCode"]));
                    command.Parameters.Add(new SqlParameter("@p_Quantity", httpRequest.QueryString["quantity"]));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            availableDepotCodes.Add((string)reader["DepotCode"]);
                        }
                    }

                    connection.Close();

                    var depotsWithProduct = allDepots.Where(depot => availableDepotCodes.Contains(depot.DepotCode));
                    context.SetVariable("depots", depotsWithProduct);
                }
                catch (Exception ex)
                {
                }

            }

            return Done();
        }
    }
}