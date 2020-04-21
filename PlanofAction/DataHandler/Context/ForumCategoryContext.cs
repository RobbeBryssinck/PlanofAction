using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using DataHandler.Models;

namespace DataHandler.Context
{
    class ForumCategoryContext
    {
        public string ConnectionString { get; set; }

        public ForumCategoryContext(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<ForumCategoryDto> GetForumCategories()
        {
            string command = "SELECT * FROM forumcategory;";
            List<ForumCategoryDto> forumCategories = new List<ForumCategoryDto>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(command, conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    forumCategories.Add(new ForumCategoryDto()
                    {
                        ForumCategoryID = Convert.ToInt32(reader["ForumCategoryID"]),
                        ForumCategoryString = reader["ForumCategoryString"].ToString(),
                    });
                }
            }
            return forumCategories;
        }

        public ForumCategoryDto GetForumCategory(int forumCategoryID)
        {
            string command = "SELECT * FROM forumcategory WHERE ForumCategoryID={0};";
            ForumCategoryDto forumCategory = new ForumCategoryDto();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, forumCategoryID.ToString()), conn);

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    forumCategory = new ForumCategoryDto()
                    {
                        ForumCategoryID = Convert.ToInt32(reader["ForumCategoryID"]),
                        ForumCategoryString = reader["ForumCategoryString"].ToString(),
                    };
                }
            }
            return forumCategory;
        }

        public int CreateForumCategory(ForumCategoryDto forumCategory)
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

        public void DeleteForumCategory(ForumCategoryDto forumCategory)
        {
            string command = "DELETE FROM forumcategory WHERE ForumCategoryID={0};";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, forumCategory.ForumCategoryID), conn);

                cmd.ExecuteNonQuery();
            }
        }

        public void EditForumCategory(ForumCategoryDto forumCategory)
        {
            string command = "UPDATE forumcategory SET ForumCategoryString='{0}' WHERE ForumCategoryID={1};";

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, forumCategory.ForumCategoryString, forumCategory.ForumCategoryID), conn);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
