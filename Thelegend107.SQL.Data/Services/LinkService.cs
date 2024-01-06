using MapDataReader;
using Microsoft.Data.SqlClient;
using ResumeAPI.Entities;
using ResumeAPI.Helpers;
using System.Data;

namespace ResumeAPI.Services
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
