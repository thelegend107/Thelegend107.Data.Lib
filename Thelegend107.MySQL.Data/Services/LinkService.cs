using MapDataReader;
using MySql.Data.MySqlClient;
using System.Data;
using Thelegend107.MySQL.Data.Lib.Entities;
using Thelegend107.MySQL.Data.Lib.Helpers;

namespace Thelegend107.MySQL.Data.Lib.Services
{
    public class LinkService
    {
        private readonly MySqlConnection _sqlConnection;

        public LinkService(MySqlConnection MySqlConnection)
        {
            _sqlConnection = MySqlConnection;
        }

        public async Task<IEnumerable<Link>> RetrieveLinks(int userId)
        {
            List<Link> links = new List<Link>();

            string sql = ObjectToSQLHelper<Link>.GenerateSelectQuery().ToString();

            using (MySqlConnection MySqlConnection = new MySqlConnection(_sqlConnection.ConnectionString))
            {
                MySqlConnection.Open();
                IDataReader dataReader = await new MySqlCommand(sql, MySqlConnection).ExecuteReaderAsync();
                links = dataReader.ToLink();
            }

            return links;
        }
    }
}
