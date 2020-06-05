using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System.IO;

namespace DataHandler
{
    public static class Connection
    {
        public static MySqlConnection GetConnection()
        {
            JObject data = JObject.Parse(File.ReadAllText(Path.Combine(Path.GetTempPath() + "ConnectionString.json")));
            string connectionString = (string)data["ConnectionString"];
            return new MySqlConnection(connectionString);
        }
    }
}
