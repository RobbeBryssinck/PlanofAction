using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataHandler.Context
{
    class ForumContext
    {
        public string ConnectionString { get; set; }

        public ForumContext(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

    }
}
