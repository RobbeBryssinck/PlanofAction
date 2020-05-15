using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using DataHandler.Models;
using DataHandlerInterfaces;

namespace DataHandler.Context
{
    public class ForumPostContext : IForumPostContext
    {
        public string ConnectionString { get; set; }

        public ForumPostContext()
        {
            ConnectionString = ConnectionStringValue.connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<IForumPostDto> GetForumPosts(int threadID)
        {
            string postsCommand = "SELECT * FROM post WHERE ThreadID='{0}';";
            List<IForumPostDto> posts = new List<IForumPostDto>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmdPosts = new MySqlCommand(string.Format(postsCommand, threadID.ToString()), conn);

                using MySqlDataReader postsReader = cmdPosts.ExecuteReader();
                while (postsReader.Read())
                {
                    posts.Add(new ForumPostDto() {
                        PostID = Convert.ToInt32(postsReader["PostID"]),
                        ThreadID = Convert.ToInt32(postsReader["ThreadID"]),
                        AccountID = Convert.ToInt32(postsReader["AccountID"]),
                        PostMessage = postsReader["PostMessage"].ToString(),
                        PostDateCreated = Convert.ToDateTime(postsReader["PostDateCreated"]),
                    });
                }
            }

            return posts;
        }

        public void CreatePost(IForumPostDto forumPostDto)
        {
            string command = "INSERT INTO `post` (`ThreadID`, `AccountID`, `PostMessage`, `PostDateCreated`) VALUES ({0}, {1}, '{2}', '{3}');";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, forumPostDto.ThreadID,
                                                                    forumPostDto.AccountID,
                                                                    forumPostDto.PostMessage,
                                                                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), conn);

                cmd.ExecuteNonQuery();
            }
        }

        public IForumPostDto GetForumPost(int postID)
        {
            string command = "SELECT * FROM post WHERE PostID={0};";
            IForumPostDto model = new ForumPostDto();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, postID.ToString()), conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    model = new ForumPostDto()
                    {
                        PostID = Convert.ToInt32(reader["PostID"]),
                        PostMessage = reader["PostMessage"].ToString(),
                        ThreadID = Convert.ToInt32(reader["ThreadID"])
                    };
                }
            }

            return model;
        }

        public void EditForumPost(IForumPostDto forumPostDto)
        {
            string command = "UPDATE post SET PostMessage='{0}' WHERE PostID={1};";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, forumPostDto.PostMessage,
                                                    forumPostDto.PostID), conn);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
