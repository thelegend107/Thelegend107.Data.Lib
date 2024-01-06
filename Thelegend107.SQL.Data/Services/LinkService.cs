using MapDataReader;
using Microsoft.Data.SqlClient;
using System.Data;
using Thelegend107.SQL.Data.Lib.Entities;
using Thelegend107.SQL.Data.Lib.Helpers;

namespace Thelegend107.SQL.Data.Lib.Services
{
    public class LinkService
    {
        private readonly SqlConnection _sqlConnection;

        public LinkService(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<IEnumerable<Link>> RetrieveLinks(int userId)
        {
            List<Link> links = new List<Link>();

            string sql = ObjectToSQLHelper<Link>.GenerateSelectQuery().ToString();

            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnection.ConnectionString))
            {
                sqlConnection.Open();
                IDataReader dataReader = await new SqlCommand(sql, sqlConnection).ExecuteReaderAsync();
                links = dataReader.ToLink();
            }

            return links;
        }
    }
}
