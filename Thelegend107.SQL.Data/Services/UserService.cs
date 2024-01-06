using MapDataReader;
using Microsoft.Data.SqlClient;
using ResumeAPI.Entities;
using ResumeAPI.Helpers;
using System.Data;

namespace ResumeAPI.Services
{
    public class UserService
    {
        private readonly SqlConnection _sqlConnection;

        public UserService(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<User?> RetrieveUserById(int? Id)
        {
            User? user = null;

            string sql = ObjectToSQLHelper<User>.GenerateSelectQuery().AppendLine($"WHERE Id = {Id}").ToString();

            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnection.ConnectionString))
            {
                sqlConnection.Open();
                IDataReader dataReader = await new SqlCommand(sql, sqlConnection).ExecuteReaderAsync();
                user = dataReader.ToUser().FirstOrDefault();
            }

            return user;
        }

        public async Task<User?> RetrieveUserByEmail(string email)
        {
            User? user = null;

            string sql = ObjectToSQLHelper<User>.GenerateSelectQuery().AppendLine($"WHERE Email = '{email.Trim()}'").ToString();

            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnection.ConnectionString))
            {
                sqlConnection.Open();
                IDataReader dataReader = await new SqlCommand(sql, sqlConnection).ExecuteReaderAsync();
                user = dataReader.ToUser().FirstOrDefault();
            }

            return user;
        }
    }
}
