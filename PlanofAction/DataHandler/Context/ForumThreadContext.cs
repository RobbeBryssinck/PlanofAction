using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using DataHandler.Models;
using DataHandler.Context;

namespace DataHandler.Context
{
    class ForumThreadContext
    {
        public string ConnectionString { get; set; }

        public ForumThreadContext(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public ForumThread GetForumThread(int threadID)
        {
            string command = "SELECT * FROM thread WHERE ThreadID='{0}';";
            ForumThread thread = new ForumThread();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, threadID.ToString()), conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    thread = new ForumThread()
                    {
                        ThreadID = Convert.ToInt32(reader["ThreadID"]),
                        AccountID = Convert.ToInt32(reader["AccountID"]),
                        ForumCategoryID = Convert.ToInt32(reader["ForumCategoryID"]),
                        ThreadTitle = reader["ThreadTitle"].ToString(),
                        ThreadMessage = reader["ThreadMessage"].ToString(),
                        ThreadDateCreated = Convert.ToDateTime(reader["ThreadDateCreated"])
                    };
                }
            }
            thread.Category = GetForumCategory(thread.ForumCategoryID);

            return thread;
        }

        public List<ForumThread> GetForumThreadsByID(int forumThreadID)
        {
            string command = "SELECT * FROM thread WHERE ForumCategoryID={0};";
            List<ForumThread> threads = new List<ForumThread>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, forumThreadID.ToString()), conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    threads.Add(new ForumThread()
                    {
                        ThreadID = Convert.ToInt32(reader["ThreadID"]),
                        AccountID = Convert.ToInt32(reader["AccountID"]),
                        ForumCategoryID = Convert.ToInt32(reader["ForumCategoryID"]),
                        ThreadTitle = reader["ThreadTitle"].ToString(),
                        ThreadMessage = reader["ThreadMessage"].ToString(),
                        ThreadDateCreated = Convert.ToDateTime(reader["ThreadDateCreated"])
                    });
                }
            }
            
            foreach (var forumThread in threads)
            {
                forumThread.Category = GetForumCategory(forumThread.ForumCategoryID);
            }

            if (threads.Count == 0)
                threads.Add(new ForumThread()
                {
                    ThreadID = -1
                });

            return threads;
        }


        public ForumThreadViewModel GetForumThreadViewModel(int threadID)
        {
            string command = "SELECT * FROM thread WHERE ThreadID='{0}';";
            int accountID = 0;
            ForumThreadViewModel forumThreadViewModel = new ForumThreadViewModel();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, threadID.ToString()), conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    forumThreadViewModel.ThreadID = Convert.ToInt32(reader["ThreadID"]);
                    forumThreadViewModel.ThreadTitle = reader["ThreadTitle"].ToString();
                    forumThreadViewModel.ThreadMessage = reader["ThreadMessage"].ToString();
                    forumThreadViewModel.ThreadDateCreated = Convert.ToDateTime(reader["ThreadDateCreated"]);

                    accountID = Convert.ToInt32(reader["AccountID"]);
                }
            }

            forumThreadViewModel.ThreadCreator = GetThreadCreator(accountID);
            forumThreadViewModel.Posts = GetPosts(threadID);

            return forumThreadViewModel;
        }

        public Account GetThreadCreator(int accountID)
        {
            string command = "SELECT * FROM account WHERE AccountID='{0}';";
            Account account = new Account();

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
}
