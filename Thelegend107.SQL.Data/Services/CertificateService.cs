using MapDataReader;
using Microsoft.Data.SqlClient;
using ResumeAPI.Entities;
using ResumeAPI.Helpers;
using System.Data;

namespace ResumeAPI.Services
{
    public class CertificateService
    {
        private readonly SqlConnection _sqlConnection;

        public CertificateService(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<IEnumerable<Certificate>> RetrieveCertifcates(int userId)
        {
            List<Certificate> certificates = new List<Certificate>();

            string sql = ObjectToSQLHelper<Certificate>.GenerateSelectQuery().ToString();

            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnection.ConnectionString))
            {
                sqlConnection.Open();
                IDataReader dataReader = await new SqlCommand(sql, sqlConnection).ExecuteReaderAsync();
                certificates = dataReader.ToCertificate();
            }

            return certificates;
        }
    }
}
