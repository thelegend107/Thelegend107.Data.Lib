using MapDataReader;
using MySql.Data.MySqlClient;
using System.Data;
using Thelegend107.MySQL.Data.Lib.Entities;
using Thelegend107.MySQL.Data.Lib.Helpers;

namespace Thelegend107.MySQL.Data.Lib.Services
{
    public class UserService
    {
        private readonly MySqlConnection _sqlConnection;

        public UserService(MySqlConnection MySqlConnection)
        {
            _sqlConnection = MySqlConnection;
        }

        public async Task<User?> RetrieveUserById(int? Id)
        {
            User? user = null;

            string sql = ObjectToSQLHelper<User>.GenerateSelectQuery().AppendLine($"WHERE Id = {Id}").ToString();

            try
            {
                using (MySqlConnection MySqlConnection = new MySqlConnection(_sqlConnection.ConnectionString))
                {
                    MySqlConnection.Open();
                    IDataReader dataReader = await new MySqlCommand(sql, MySqlConnection).ExecuteReaderAsync();
                    user = dataReader.ToUser().FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return user;
        }

        public async Task<User?> RetrieveUserByEmail(string email)
        {
            User? user = null;

            string sql = ObjectToSQLHelper<User>.GenerateSelectQuery().AppendLine($"WHERE Email = '{email.Trim()}'").ToString();

            using (MySqlConnection MySqlConnection = new MySqlConnection(_sqlConnection.ConnectionString))
            {
                MySqlConnection.Open();
                IDataReader dataReader = await new MySqlCommand(sql, MySqlConnection).ExecuteReaderAsync();
                user = dataReader.ToUser().FirstOrDefault();
            }

            return user;
        }
    }
}
