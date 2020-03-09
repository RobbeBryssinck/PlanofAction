using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PlanofAction.Models
{
    public class PoAContext
    {
        public string ConnectionString { get; set; }

        public PoAContext(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public bool LoginQuery(string username, string password)
        {
            string command = "SELECT Password FROM account WHERE Username='{0}';";
            bool flag = false;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, username), conn);
                
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string newpass = reader["Password"].ToString();
                    if (reader["Password"].ToString() == password)
                        flag = true;
                    else
                        flag = false;
                }
            }
            return flag;
        }
    }
}
