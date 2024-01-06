using MapDataReader;
using MySql.Data.MySqlClient;
using apiV2.Entities;
using apiV2.Helpers;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace apiV2.Services
{
    public class WorkExperienceService
    {
        private readonly MySqlConnection _sqlConnection;
        private readonly AddressService _addressService;

        public WorkExperienceService(MySqlConnection MySqlConnection, AddressService addressService)
        {
            _sqlConnection = MySqlConnection;
            _addressService = addressService;
        }

        public async Task<IEnumerable<WorkExperience>> RetrieveWorkExperiences(int userId)
        {
            List<WorkExperience> workExperiences = new List<WorkExperience>();

            string sql = ObjectToSQLHelper<WorkExperience>.GenerateSelectQuery().ToString();

            using (MySqlConnection MySqlConnection = new MySqlConnection(_sqlConnection.ConnectionString))
            {
                MySqlConnection.Open();
                IDataReader dataReader = await new MySqlCommand(sql, MySqlConnection).ExecuteReaderAsync();
                workExperiences = dataReader.ToWorkExperience();
            }

            Parallel.ForEach(workExperiences, workExperience =>
            {
                workExperience.Address = _addressService.RetrieveAddressById(workExperience.AddressId).Result;
                workExperience.WorkExperienceItems = RetrieveWorkExperienceItems(workExperience.Id).Result;
            });

            return workExperiences;
        }

        private async Task<IEnumerable<WorkExperienceItem>> RetrieveWorkExperienceItems(int workExperienceId)
        {
            List<WorkExperienceItem> workExperienceItems = new List<WorkExperienceItem>();

            string sql = ObjectToSQLHelper<WorkExperienceItem>.GenerateSelectQuery()
                .AppendLine($"WHERE WorkExperienceId = {workExperienceId}")
                .ToString();

            using (MySqlConnection MySqlConnection = new MySqlConnection(_sqlConnection.ConnectionString))
            {
                MySqlConnection.Open();
                IDataReader dataReader = await new MySqlCommand(sql, MySqlConnection).ExecuteReaderAsync();
                workExperienceItems = dataReader.ToWorkExperienceItem();
            }

            return workExperienceItems;
        }
    }
}
