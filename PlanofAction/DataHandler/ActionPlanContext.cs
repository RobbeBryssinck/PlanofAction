using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DataHandler
{
    public class ActionPlanContext
    {
        public string ConnectionString { get; set; }

        public ActionPlanContext(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<ActionPlanDto> GetActionPlans()
        {
            string command = "SELECT * FROM actionplan;";
            List<ActionPlanDto> actionPlans = new List<ActionPlanDto>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(command, conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    actionPlans.Add(new ActionPlanDto()
                    {
                        ActionPlanID = Convert.ToInt32(reader["ActionPlanID"]),
                        AccountID = Convert.ToInt32(reader["AccountID"]),
                        PlanTitle = reader["PlanTitle"].ToString(),
                        PlanMessage = reader["PlanMessage"].ToString(),
                        PlanCategory = reader["PlanCategory"].ToString(),
                        PlanDateCreated = Convert.ToDateTime(reader["PlanDateCreated"])
                    });
                }
            }
            return actionPlans;
        }
    }
}
