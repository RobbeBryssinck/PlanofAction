﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PlanofAction.ViewModels;

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

        public List<ActionPlan> GetActionPlans()
        {
            string command = "SELECT * FROM actionplan;";
            List<ActionPlan> actionPlans = new List<ActionPlan>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(command, conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    actionPlans.Add(new ActionPlan()
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

        public ActionPlan GetActionPlan(int actionPlanID)
        {
            string command = "SELECT * FROM actionplan WHERE ActionPlanID='{0}';";
            ActionPlan actionPlan = new ActionPlan();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, actionPlanID.ToString()), conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    actionPlan = new ActionPlan()
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

        public int CreateActionPlan(ActionPlan actionPlan)
        {
            string command = "INSERT INTO `actionplan` (`AccountID`, `PlanTitle`, `PlanMessage`, `PlanCategory`, `PlanDateCreated`) VALUES ({0}, '{1}', '{2}', '{3}', '{4}');";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, actionPlan.AccountID, actionPlan.PlanTitle,
                                                                    actionPlan.PlanMessage, actionPlan.PlanCategory,
                                                                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), conn);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;
            }
        }

        public void DeleteActionPlan(ActionPlan actionPlan)
        {
            string command = "DELETE FROM actionplan WHERE ActionPlanID={0};";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, actionPlan.ActionPlanID), conn);

                cmd.ExecuteNonQuery();
            }
        }

        public void EditActionPlan(ActionPlan actionPlan)
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

        public List<Thread> GetForumThreads()
        {
            string command = "SELECT * FROM thread;";
            List<Thread> threads = new List<Thread>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(command, conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    threads.Add(new Thread()
                    {
                        ThreadID = Convert.ToInt32(reader["ThreadID"]),
                        AccountID = Convert.ToInt32(reader["AccountID"]),
                        ThreadTitle = reader["ThreadTitle"].ToString(),
                        ThreadMessage = reader["ThreadMessage"].ToString(),
                        ThreadCategory = reader["ThreadCategory"].ToString(),
                        ThreadDateCreated = Convert.ToDateTime(reader["ThreadDateCreated"])
                    });
                }
            }
            return threads;
        }

        public Thread GetForumThread(int threadID)
        {
            string command = "SELECT * FROM thread WHERE ThreadID='{0}';";
            Thread thread = new Thread();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, threadID.ToString()), conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    thread = new Thread()
                    {
                        ThreadID = Convert.ToInt32(reader["ThreadID"]),
                        AccountID = Convert.ToInt32(reader["AccountID"]),
                        ThreadTitle = reader["ThreadTitle"].ToString(),
                        ThreadMessage = reader["ThreadMessage"].ToString(),
                        ThreadCategory = reader["ThreadCategory"].ToString(),
                        ThreadDateCreated = Convert.ToDateTime(reader["ThreadDateCreated"])
                    };
                }
            }
            return thread;
        }

        public ForumPostViewModel GetForumThreadViewModel(int threadID)
        {
            string command = "SELECT * FROM thread WHERE ThreadID='{0}';";
            ForumPostViewModel forumPostViewModel = new ForumPostViewModel();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, threadID.ToString()), conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    forumPostViewModel = new ForumPostViewModel()
                    {
                        ThreadTitle = reader["ThreadTitle"].ToString(),
                        ThreadMessage = reader["ThreadMessage"].ToString(),
                        ThreadCategory = reader["ThreadCategory"].ToString(),
                        ThreadDateCreated = Convert.ToDateTime(reader["ThreadDateCreated"])
                    };
                }
            }

            forumPostViewModel.Posts = GetPosts(threadID);

            return forumPostViewModel;
        }

        public List<Post> GetPosts(int threadID)
        {
            string command = "SELECT * FROM post WHERE ThreadID='{0}';";
            List<Post> posts = new List<Post>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, threadID.ToString()), conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    posts.Add(new Post()
                    {
                        PostID = Convert.ToInt32(reader["PostID"]),
                        ThreadID = Convert.ToInt32(reader["ThreadID"]),
                        AccountID = Convert.ToInt32(reader["AccountID"]),
                        PostMessage = reader["PostMessage"].ToString(),
                        PostDateCreated = Convert.ToDateTime(reader["PostDateCreated"])
                    });
                }
            }

            return posts;
        }

        public int CreateThread(Thread thread)
        {
            string command = "INSERT INTO `thread` (`AccountID`, `ThreadTitle`, `ThreadMessage`, `ThreadCategory`, `ThreadDateCreated`) VALUES ({0}, '{1}', '{2}', '{3}', '{4}');";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, thread.AccountID, thread.ThreadTitle,
                                                                    thread.ThreadMessage, thread.ThreadCategory,
                                                                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), conn);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;
            }
        }

        public void DeleteThread(Thread thread)
        {
            string command = "DELETE FROM thread WHERE ThreadID={0};";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, thread.ThreadID), conn);

                cmd.ExecuteNonQuery();
            }
        }

        public void EditThread(Thread thread)
        {
            string command = "UPDATE thread SET ThreadTitle='{0}', ThreadMessage='{1}', ThreadCategory='{2}' WHERE ThreadID={3};";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, thread.ThreadTitle, thread.ThreadMessage,
                    thread.ThreadCategory, thread.ThreadID), conn);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
