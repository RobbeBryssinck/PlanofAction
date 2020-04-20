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

        public ActionPlanDto GetActionPlan(int actionPlanID)
        {
            string command = "SELECT * FROM actionplan WHERE ActionPlanID='{0}';";
            ActionPlanDto actionPlan = new ActionPlanDto();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, actionPlanID.ToString()), conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    actionPlan = new ActionPlanDto()
                    {
                        ActionPlanID = Convert.ToInt32(reader["ActionPlanID"]),
                        AccountID = Convert.ToInt32(reader["AccountID"]),
                        PlanTitle = reader["PlanTitle"].ToString(),
                        PlanMessage = reader["PlanMessage"].ToString(),
                        PlanCategory = reader["PlanCategory"].ToString(),
                        PlanDateCreated = Convert.ToDateTime(reader["PlanDateCreated"])
                    };
                }
            }
            return actionPlan;
        }

        public int CreateActionPlan(int accountID, string planTitle, string planMessage, string planCategory)
        {
            string command = "INSERT INTO `actionplan` (`AccountID`, `PlanTitle`, `PlanMessage`, `PlanCategory`, `PlanDateCreated`) VALUES ({0}, '{1}', '{2}', '{3}', '{4}');";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, accountID, planTitle,
                                                                    planMessage, planCategory,
                                                                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), conn);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;
            }
        }

        public void DeleteActionPlan(ActionPlanDto actionPlan)
        {
            string command = "DELETE FROM actionplan WHERE ActionPlanID={0};";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, actionPlan.ActionPlanID), conn);

                cmd.ExecuteNonQuery();
            }
        }

        public void EditActionPlan(ActionPlanDto actionPlan)
        {
            string command = "UPDATE actionplan SET PlanTitle='{0}', PlanMessage='{1}', PlanCategory='{2}' WHERE ActionPlanID={3};";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, actionPlan.PlanTitle, actionPlan.PlanMessage,
                    actionPlan.PlanCategory, actionPlan.ActionPlanID), conn);

                cmd.ExecuteNonQuery();
            }
        }

    }
}
