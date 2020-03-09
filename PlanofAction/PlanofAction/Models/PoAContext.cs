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

        public List<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM account", conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    accounts.Add(new Account()
                    {
                        AccountID = Convert.ToInt32(reader["AccountID"]),
                        Username = reader["Username"].ToString(),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString(),
                        Role = reader["Role"].ToString()
                    });
                }
            }
            return accounts;
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

        // TODO: write register function
        public void Register()
        {
            string command = "INSERT INTO `account` (`Username`, `Password`, `Role`) VALUES ('{0}','{1}','{2}');";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                //MySqlCommand cmd = new MySqlCommand(string.Format(command, ));
            }
        }
    }
}
