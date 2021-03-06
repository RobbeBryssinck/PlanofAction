﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using DataHandler.Models;
using DataHandlerInterfaces;

namespace DataHandler.Context
{
    public class ForumCategoryContext : IForumCategoryContext
    {
        public List<IForumCategoryDto> GetForumCategories()
        {
            string command = "SELECT * FROM forumcategory;";
            List<IForumCategoryDto> forumCategories = new List<IForumCategoryDto>();

            using (MySqlConnection conn = Connection.GetConnection())
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

        public IForumCategoryDto GetForumCategory(int forumCategoryID)
        {
            string command = "SELECT * FROM forumcategory WHERE ForumCategoryID={0};";
            IForumCategoryDto forumCategory = new ForumCategoryDto();

            using (MySqlConnection conn = Connection.GetConnection())
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

        public int CreateForumCategory(IForumCategoryDto forumCategory)
        {
            string command = "INSERT INTO `forumcategory` (`ForumCategoryString`) VALUES ('{0}');";

            using (MySqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, forumCategory.ForumCategoryString), conn);

                int rowcount = cmd.ExecuteNonQuery();
                return rowcount;
            }
        }

        public void DeleteForumCategory(int forumCategoryID)
        {
            string command = "DELETE FROM forumcategory WHERE ForumCategoryID={0};";

            using (MySqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, forumCategoryID), conn);

                cmd.ExecuteNonQuery();
            }
        }

        public void EditForumCategory(IForumCategoryDto forumCategory)
        {
            string command = "UPDATE forumcategory SET ForumCategoryString='{0}' WHERE ForumCategoryID={1};";

            using (MySqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(string.Format(command, forumCategory.ForumCategoryString, forumCategory.ForumCategoryID), conn);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
