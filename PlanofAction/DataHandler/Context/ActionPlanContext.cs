using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using DataHandler.Models;
using DataHandlerInterfaces;

namespace DataHandler.Context
{
    public class ActionPlanContext : IActionPlanContext
    {
        public string ConnectionString { get; set; }

        public ActionPlanContext()
        {
            ConnectionString = ConnectionStringValue.connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<IActionPlanDto> GetActionPlans()
        {
            string command = "SELECT * FROM actionplan;";
            List<IActionPlanDto> actionPlans = new List<IActionPlanDto>();

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

        public IActionPlanDto GetActionPlan(int actionPlanID)
        {
            string command = "SELECT * FROM actionplan WHERE ActionPlanID='{0}';";
            IActionPlanDto actionPlan = new ActionPlanDto();

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

        public void CreateActionPlan(IActionPlanDto actionPlanDto)
        {
            string command = "INSERT INTO `actionplan` (`AccountID`, `PlanTitle`, `PlanMessage`, `PlanCategory`, `PlanDateCreated`) VALUES ({0}, '{1}', '{2}', '{3}', '{4}');";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, actionPlanDto.AccountID, actionPlanDto.PlanTitle,
                                                                    actionPlanDto.PlanMessage, actionPlanDto.PlanCategory,
                                                                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), conn);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteActionPlan(int actionPlanID)
        {
            string command = "DELETE FROM actionplan WHERE ActionPlanID={0};";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, actionPlanID), conn);

                cmd.ExecuteNonQuery();
            }
        }

        public void EditActionPlan(string planTitle, string planMessage, string planCategory, int actionPlanID)
        {
            string command = "UPDATE actionplan SET PlanTitle='{0}', PlanMessage='{1}', PlanCategory='{2}' WHERE ActionPlanID={3};";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, planTitle, planMessage,
                    planCategory, actionPlanID), conn);

                cmd.ExecuteNonQuery();
            }
        }

    }
}
