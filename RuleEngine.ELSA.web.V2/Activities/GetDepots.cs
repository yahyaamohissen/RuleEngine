using Elsa.Activities.Http.Models;
using Elsa.ActivityResults;
using Elsa.Attributes;
using Elsa.Services;
using Elsa.Services.Models;
using RuleEngine.ELSA.web.V2.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace RuleEngine.ELSA.web.V2.Activities
{
    [Activity(Category = "Depot Rules", Description = "This is one of the depot rules engine. this should be the first one", DisplayName = "Get list of depots")]
    public class GetDepots : Activity
    {
        [Required]
        [ActivityInput(Hint = "Number of lines to be added, if not provided will be random.", Name = "Max Number Of Depots to be returned")]
        public int MaxNumberOfDepots { get; set; }

        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
            var connectionString = "Server=tcp:sppedyserver.database.windows.net,1433;Initial Catalog=DepotAllocation;Persist Security Info=False;User ID=Nidal;Password=Momani@1992;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            string SQL = "[dbo].[usp_getNearestDepots]";

            var depots = new List<Depot>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try 
                {
                    var httpRequest = (HttpRequestModel)context.Input;
                    connection.Open();

                    SqlCommand command = new SqlCommand(SQL, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@p_latitude", httpRequest.QueryString["lat"]));
                    command.Parameters.Add(new SqlParameter("@p_longitude", httpRequest.QueryString["llong"]));
                    command.Parameters.Add(new SqlParameter("@p_radius", httpRequest.QueryString["rad"]));
                    command.Parameters.Add(new SqlParameter("@p_returnCount", 100));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Boolean.TryParse(reader["IsCapable"].ToString(), out var isCapable);
                            Boolean.TryParse(reader["IsClickAndCollect"].ToString(), out var isClickAndCollect);
                            Boolean.TryParse(reader["IsOpen"].ToString(), out var isOpen);
                            Boolean.TryParse(reader["IsDelivery"].ToString(), out var isDelivery);

                            depots.Add(new Depot()
                            {
                                ID = (int)reader["Id"],
                                DepotCode = (string)reader["DepotCode"],
                                DepotName = (string)reader["DepotName"],
                                IsCapable = isCapable,
                                IsClickAndCollect = isClickAndCollect,
                                IsOpen = isOpen,
                                IsDelivery = isDelivery
                            });
                        }
                    }

                    connection.Close();
                    context.SetVariable("depots", depots);
                }
                catch(Exception ex) 
                {
                }
                
            }

            //var list = new List<int>() { 5, 5, 5, 5, 5, 5, 5, 5 };
            //context.SetVariable("depots", list);
            return Done();
        }
    }
}