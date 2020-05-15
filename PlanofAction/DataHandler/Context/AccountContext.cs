using System;
using System.Collections.Generic;
using System.Text;
using DataHandler.Models;
using DataHandlerInterfaces;
using MySql.Data.MySqlClient;

namespace DataHandler.Context
{
    public class AccountContext : IAccountContext
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

        public List<IAccountDto> GetAccounts()
        {
            string command = "SELECT * FROM account;";
            List<IAccountDto> accounts = new List<IAccountDto>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(command, conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    accounts.Add(new AccountDto()
                    {
                    AccountID = Convert.ToInt32(reader["AccountID"]),
                    Username = reader["Username"].ToString(),
                    Email = reader["Email"].ToString(),
                    Password = reader["Password"].ToString(),
                    Role = reader["Role"].ToString(),
                    ProfilePicture = reader["ProfilePicture"].ToString(),
                    DateJoined = Convert.ToDateTime(reader["DateJoined"]).ToString("dd-MM-yyyy")
                    });
                }
            }

            return accounts;
        }

        public IAccountDto GetAccount(int accountID)
        {
            string command = "SELECT * FROM account WHERE AccountID='{0}';";
            IAccountDto account = new AccountDto();

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

        public IAccountDto GetAccount(string username)
        {
            string accountCommand = "SELECT * FROM account WHERE Username='{0}';";
            IAccountDto account = new AccountDto();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                MySqlCommand cmdAccount = new MySqlCommand(string.Format(accountCommand, username), conn);

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
