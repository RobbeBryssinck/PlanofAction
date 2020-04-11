using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PlanofAction.Models;
using PlanofAction.ViewModels;

namespace PlanofAction.Data
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

        public List<ForumCategory> GetForumCategories()
        {
            string command = "SELECT * FROM forumcategory;";
            List<ForumCategory> forumCategories = new List<ForumCategory>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(command, conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    forumCategories.Add(new ForumCategory()
                    {
                        ForumCategoryID = Convert.ToInt32(reader["ForumCategoryID"]),
                        ForumCategoryString = reader["ForumCategoryString"].ToString(),
                    });
                }
            }
            return forumCategories;
        }

        public ForumCategory GetForumCategory(int forumCategoryID)
        {
            string command = "SELECT * FROM forumcategory WHERE ForumCategoryID={0};";
            ForumCategory forumCategory = new ForumCategory();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(command, conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    forumCategory = new ForumCategory()
                    {
                        ForumCategoryID = Convert.ToInt32(reader["ForumCategoryID"]),
                        ForumCategoryString = reader["ForumCategoryString"].ToString(),
                    };
                }
            }
            return forumCategory;
        }

        public int CreateForumCategory(ForumCategory forumCategory)
        {
            string command = "INSERT INTO `forumcategory` (`ForumCategoryID`, `ForumCategoryString`) VALUES ({0}, '{1}');";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, forumCategory.ForumCategoryID, forumCategory.ForumCategoryString), conn);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;
            }
        }

        public void DeleteForumCategory(ForumCategory forumCategory)
        {
            string command = "DELETE FROM forumcategory WHERE ForumCategoryID={0};";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, forumCategory.ForumCategoryID), conn);

                cmd.ExecuteNonQuery();
            }
        }

        public void EditForumCategory(ForumCategory forumCategory)
        {
            string command = "UPDATE forumcategory SET ForumCategoryString='{0}';";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, forumCategory.ForumCategoryString), conn);

                cmd.ExecuteNonQuery();
            }
        }

        public List<ForumThread> GetForumThreads()
        {
            string command = "SELECT * FROM thread;";
            List<ForumThread> threads = new List<ForumThread>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(command, conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    threads.Add(new ForumThread()
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
            int accountID = 0;
            ForumPostViewModel forumPostViewModel = new ForumPostViewModel();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, threadID.ToString()), conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    forumPostViewModel.ThreadTitle = reader["ThreadTitle"].ToString();
                    forumPostViewModel.ThreadMessage = reader["ThreadMessage"].ToString();
                    forumPostViewModel.ThreadCategory = reader["ThreadCategory"].ToString();
                    forumPostViewModel.ThreadDateCreated = Convert.ToDateTime(reader["ThreadDateCreated"]);

                    accountID = Convert.ToInt32(reader["AccountID"]);
                }
            }

            forumPostViewModel.ThreadCreator = GetThreadCreator(accountID);
            forumPostViewModel.Posts = GetPosts(threadID);

            return forumPostViewModel;
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

        public List<Post> GetPosts(int threadID)
        {
            string postsCommand = "SELECT * FROM post WHERE ThreadID='{0}';";
            List<Post> posts = new List<Post>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmdPosts = new MySqlCommand(string.Format(postsCommand, threadID.ToString()), conn);

                using MySqlDataReader postsReader = cmdPosts.ExecuteReader();
                while (postsReader.Read())
                {
                    Post post = new Post();
                    post.PostID = Convert.ToInt32(postsReader["PostID"]);
                    post.ThreadID = Convert.ToInt32(postsReader["ThreadID"]);
                    post.AccountID = Convert.ToInt32(postsReader["AccountID"]);
                    post.PostMessage = postsReader["PostMessage"].ToString();
                    post.PostDateCreated = Convert.ToDateTime(postsReader["PostDateCreated"]);

                    post.PostAccount = GetAccount(postsReader["AccountID"].ToString());

                    posts.Add(post);
                }
            }

            return posts;
        }

        public Account GetAccount(string accountID)
        {
            string accountCommand = "SELECT * FROM account WHERE AccountID='{0}';";
            Account account = new Account();

            using (MySqlConnection conn2 = GetConnection())
            {
                conn2.Open();

                MySqlCommand cmdAccount = new MySqlCommand(string.Format(accountCommand, accountID), conn2);

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

        public int CreateThread(ForumThread thread)
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
