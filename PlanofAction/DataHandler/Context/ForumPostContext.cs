using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using DataHandler.Models;

namespace DataHandler.Context
{
    class ForumPostContext
    {
        public string ConnectionString { get; set; }

        public ForumPostContext(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
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

        public void CreatePost(ForumThreadViewModel forumThreadViewModel)
        {
            string command = "INSERT INTO `post` (`ThreadID`, `AccountID`, `PostMessage`, `PostDateCreated`) VALUES ({0}, {1}, '{2}', '{3}');";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, forumThreadViewModel.ThreadID,
                                                                    forumThreadViewModel.PosterAccountID,
                                                                    forumThreadViewModel.PosterMessage,
                                                                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), conn);

                cmd.ExecuteNonQuery();
            }
        }

        public PostEditViewModel GetPostEditViewModel(int postID)
        {
            string command = "SELECT * FROM post WHERE PostID={0};";
            PostEditViewModel model = new PostEditViewModel();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, postID.ToString()), conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    model = new PostEditViewModel()
                    {
                        PostID = Convert.ToInt32(reader["PostID"]),
                        PostMessage = reader["PostMessage"].ToString(),
                        ThreadID = Convert.ToInt32(reader["ThreadID"])
                    };
                }
            }

            return model;
        }

        public void EditPost(PostEditViewModel model)
        {
            string command = "UPDATE post SET PostMessage='{0}' WHERE PostID={1};";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, model.PostMessage,
                                                    model.PostID), conn);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
