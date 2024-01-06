using MapDataReader;
using Microsoft.Data.SqlClient;
using ResumeAPI.Entities;
using ResumeAPI.Helpers;
using System.Data;

namespace ResumeAPI.Services
{
    public class EducationService
    {
        private readonly SqlConnection _sqlConnection;
        private readonly AddressService _addressService;

        public EducationService(SqlConnection sqlConnection, AddressService addressService)
        {
            _sqlConnection = sqlConnection;
            _addressService = addressService;
        }

        public async Task<IEnumerable<Education>> RetrieveEducations(int userId)
        {
            List<Education> educations = new List<Education>();

            string sql = ObjectToSQLHelper<Education>.GenerateSelectQuery().ToString();

            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnection.ConnectionString))
            {
                sqlConnection.Open();
                IDataReader dataReader = await new SqlCommand(sql, sqlConnection).ExecuteReaderAsync();
                educations = dataReader.ToEducation();
            }

            Parallel.ForEach(educations, education =>
            {
                education.Address = _addressService.RetrieveAddressById(education.AddressId).Result;
                education.EducationItems = RetrieveEducationItems(education.Id).Result;
            });

            return educations;
        }

        private async Task<IEnumerable<EducationItem>> RetrieveEducationItems(int educationId)
        {
            List<EducationItem> educationItems = new List<EducationItem>();

            string sql = ObjectToSQLHelper<EducationItem>.GenerateSelectQuery()
                .AppendLine($"WHERE EducationId = {educationId}")
                .ToString();

            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnection.ConnectionString))
            {
                sqlConnection.Open();
                IDataReader dataReader = await new SqlCommand(sql, sqlConnection).ExecuteReaderAsync();
                educationItems = dataReader.ToEducationItem();
            }

            return educationItems;
        }
    }
}
