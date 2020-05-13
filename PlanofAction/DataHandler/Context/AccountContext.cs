using System;
using System.Collections.Generic;
using System.Text;
using DataHandler.Models;
using MySql.Data.MySqlClient;

namespace DataHandler.Context
{
    class AccountContext
    {
        public string ConnectionString { get; set; }

        public AccountContext()
        {
            ConnectionString = ConnectionStringValue.connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public AccountDto GetThreadCreator(int accountID)
        {
            string command = "SELECT * FROM account WHERE AccountID='{0}';";
            AccountDto account = new AccountDto();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, accountID.ToString()), conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    account.AccountID = Convert.ToInt32(reader["AccountID"]);
                    account.Username = reader["Username"].ToString();
                    account.Email = reader["Email"].ToString();
                    account.Password = reader["Password"].ToString();
                    account.Role = reader["Role"].ToString();
                    account.ProfilePicture = reader["ProfilePicture"].ToString();
                    account.DateJoined = Convert.ToDateTime(reader["DateJoined"]).ToString("dd-MM-yyyy");
                }
            }

            return account;
        }

        public AccountDto GetAccount(string accountID)
        {
            string accountCommand = "SELECT * FROM account WHERE AccountID='{0}';";
            AccountDto account = new AccountDto();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                MySqlCommand cmdAccount = new MySqlCommand(string.Format(accountCommand, accountID), conn);

                using MySqlDataReader accountReader = cmdAccount.ExecuteReader();
                while (accountReader.Read())
                {
                    account.AccountID = Convert.ToInt32(accountReader["AccountID"]);
                    account.Username = accountReader["Username"].ToString();
                    account.Email = accountReader["Email"].ToString();
                    account.Password = accountReader["Password"].ToString();
                    account.Role = accountReader["Role"].ToString();
                    account.ProfilePicture = accountReader["ProfilePicture"].ToString();
                    account.DateJoined = Convert.ToDateTime(accountReader["DateJoined"]).ToString("dd-MM-yyyy");
                }
            }

            return account;
        }
    }
}
