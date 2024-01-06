using MapDataReader;
using MySql.Data.MySqlClient;
using apiV2.Entities;
using apiV2.Helpers;
using System.Data;

namespace apiV2.Services
{
    public class AddressService
    {
        private readonly MySqlConnection _sqlConnection;

        public AddressService(MySqlConnection MySqlConnection)
        {
            _sqlConnection = MySqlConnection;
        }

        public async Task<Address?> RetrieveAddressById(int? id)
        {
            Address? address = null;

            string sql = ObjectToSQLHelper<Address>.GenerateSelectQuery().AppendLine($"WHERE Id = {id}").ToString();

            using (MySqlConnection MySqlConnection = new MySqlConnection(_sqlConnection.ConnectionString))
            {
                MySqlConnection.Open();
                IDataReader dataReader = await new MySqlCommand(sql, MySqlConnection).ExecuteReaderAsync();
                address = dataReader.ToAddress().FirstOrDefault();
            }

            if (address != null)
            {
                Task<Country?> countryTask = RetrieveAddressCountryById(address.CountryId);
                Task<State?> stateTask = RetrieveAddressStateById(address.StateId);

                Task.WaitAll(countryTask, stateTask);

                address.Country = countryTask.Result;
                address.State = stateTask.Result;
            }

            return address;
        }

        public async Task<Country?> RetrieveAddressCountryById(int? id)
        {
            Country? country = null;

            string sql = ObjectToSQLHelper<Country>.GenerateSelectQuery().AppendLine($"WHERE Id = {id}").ToString();


            using (MySqlConnection MySqlConnection = new MySqlConnection(_sqlConnection.ConnectionString))
            {
                MySqlConnection.Open();
                IDataReader dataReader = await new MySqlCommand(sql, MySqlConnection).ExecuteReaderAsync();
                country = dataReader.ToCountry().FirstOrDefault();
            }

            return country;
        }

        public async Task<State?> RetrieveAddressStateById(int? id)
        {
            State? state = null;

            string sql = ObjectToSQLHelper<State>.GenerateSelectQuery().AppendLine($"WHERE Id = {id}").ToString();


            using (MySqlConnection MySqlConnection = new MySqlConnection(_sqlConnection.ConnectionString))
            {
                MySqlConnection.Open();
                IDataReader dataReader = await new MySqlCommand(sql, MySqlConnection).ExecuteReaderAsync();
                state = dataReader.ToState().FirstOrDefault();
            }

            return state;
        }
    }
}
