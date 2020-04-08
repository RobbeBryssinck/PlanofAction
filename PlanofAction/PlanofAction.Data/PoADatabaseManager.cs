using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PlanofAction.Data
{
    public class PoADatabaseManager
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PlanofAction;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<ActionPlanDto> GetAllActionPlans()
        {
            List<ActionPlanDto> actionPlans = new List<ActionPlanDto>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("SELECT * FROM actionplan;", conn))
                {
                    conn.Open();

                    var reader = query.ExecuteReader();
                    while(reader.Read())
                    {
                        ActionPlanDto actionPlan = new ActionPlanDto();
                        actionPlan.AccountID = reader.GetInt32(0);
                        actionPlan.ActionPlanID = reader.GetInt32(1);
                        actionPlan.PlanTitle = reader.GetString(2);
                        actionPlan.PlanMessage = reader.GetString(3);
                        actionPlan.PlanCategory = reader.GetString(4);
                        actionPlan.PlanDateCreated = reader.GetDateTime(5);

                        actionPlans.Add(actionPlan);
                    }
                }
            }

            return actionPlans;
        }
    }
}
