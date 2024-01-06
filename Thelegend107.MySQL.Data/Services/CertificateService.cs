using MapDataReader;
using MySql.Data.MySqlClient;
using System.Data;
using Thelegend107.MySQL.Data.Lib.Entities;
using Thelegend107.MySQL.Data.Lib.Helpers;

namespace Thelegend107.MySQL.Data.Lib.Services
{
    public class CertificateService
    {
        private readonly MySqlConnection _sqlConnection;

        public CertificateService(MySqlConnection MySqlConnection)
        {
            _sqlConnection = MySqlConnection;
        }

        public async Task<IEnumerable<Certificate>> RetrieveCertifcates(int userId)
        {
            List<Certificate> certificates = new List<Certificate>();

            string sql = ObjectToSQLHelper<Certificate>.GenerateSelectQuery().ToString();

            using (MySqlConnection MySqlConnection = new MySqlConnection(_sqlConnection.ConnectionString))
            {
                MySqlConnection.Open();
                IDataReader dataReader = await new MySqlCommand(sql, MySqlConnection).ExecuteReaderAsync();
                certificates = dataReader.ToCertificate();
            }

            return certificates;
        }
    }
}
