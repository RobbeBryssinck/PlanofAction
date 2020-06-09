using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using DataHandler.Models;
using DataHandler.Context;
using DataHandlerInterfaces;

namespace DataHandler.Context
{
    public class ForumThreadContext : IForumThreadContext
    {
        public List<IForumThreadDto> GetForumThreads(int categoryID)
        {
            string command = "SELECT * FROM thread WHERE ForumCategoryID={0};";
            List<IForumThreadDto> threads = new List<IForumThreadDto>();

            using (MySqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, categoryID), conn);

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

            // TODO: fix whatever this is
            if (threads.Count == 0)
                threads.Add(new ForumThreadDto()
                {
                    ThreadID = -1
                });

            return threads;
        }

        public IForumThreadDto GetForumThread(int threadID)
        {
            string command = "SELECT * FROM thread WHERE ThreadID='{0}';";
            ForumThreadDto thread = new ForumThreadDto();

            using (MySqlConnection conn = Connection.GetConnection())
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

            return thread;
        }

        public int CreateThread(IForumThreadDto forumThreadDto)
        {
            string command = "INSERT INTO `thread` (`AccountID`, `ForumCategoryID`, `ThreadTitle`, `ThreadMessage`, `ThreadDateCreated`) VALUES ({0}, '{1}', '{2}', '{3}', '{4}');";

            using (MySqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, forumThreadDto.AccountID, forumThreadDto.ForumCategoryID,
                                                                    forumThreadDto.ThreadTitle, forumThreadDto.ThreadMessage,
                                                                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), conn);

                int rowcount = cmd.ExecuteNonQuery();
                return rowcount;
            }
        }

        public void DeleteThread(int threadID)
        {
            string command = "DELETE FROM thread WHERE ThreadID={0};";

            using (MySqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, threadID), conn);

                cmd.ExecuteNonQuery();
            }
        }

        public void EditThread(IForumThreadDto forumThreadDto)
        {
            string command = "UPDATE thread SET ThreadMessage='{0}' WHERE ThreadID={1};";

            using (MySqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, forumThreadDto.ThreadMessage,
                                                    forumThreadDto.ThreadID), conn);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
