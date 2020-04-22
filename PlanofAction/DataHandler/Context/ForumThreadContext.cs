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

        public List<ForumThreadDto> GetForumThreads()
        {
            string command = "SELECT * FROM thread;";
            List<ForumThreadDto> threads = new List<ForumThreadDto>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(command, conn);

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

            return threads;
        }
    }
}
