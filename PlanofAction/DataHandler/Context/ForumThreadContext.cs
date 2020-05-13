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

        public ForumThreadContext()
        {
            ConnectionString = ConnectionStringValue.connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public ForumThreadDto GetForumThread(int threadID)
        {
            string command = "SELECT * FROM thread WHERE ThreadID='{0}';";
            ForumThreadDto thread = new ForumThreadDto();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, threadID.ToString()), conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    thread = new ForumThreadDto()
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
            thread.Category = forumCategoryContext.GetForumCategory(thread.ForumCategoryID);

            return thread;
        }

        public List<ForumThreadDto> GetForumThreadsByID(int forumThreadID)
        {
            string command = "SELECT * FROM thread WHERE ForumCategoryID={0};";
            List<ForumThreadDto> threads = new List<ForumThreadDto>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, forumThreadID.ToString()), conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    threads.Add(new ForumThreadDto()
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
                threads.Add(new ForumThreadDto()
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
        
        public int CreateThread(CreateForumThreadViewModel thread)
        {
            string command = "INSERT INTO `thread` (`AccountID`, `ForumCategoryID`, `ThreadTitle`, `ThreadMessage`, `ThreadDateCreated`) VALUES ({0}, '{1}', '{2}', '{3}', '{4}');";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, thread.AccountID, thread.CategoryID,
                                                                    thread.ThreadTitle, thread.ThreadMessage,
                                                                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), conn);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;
            }
        }

        public void DeleteThread(ForumThread thread)
        {
            string command = "DELETE FROM thread WHERE ThreadID={0};";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, thread.ThreadID), conn);

                cmd.ExecuteNonQuery();
            }
        }

        public void EditThread(ForumThread thread)
        {
            string command = "UPDATE thread SET ThreadMessage='{0}' WHERE ThreadID={1};";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, thread.ThreadMessage,
                                                    thread.ThreadID), conn);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
