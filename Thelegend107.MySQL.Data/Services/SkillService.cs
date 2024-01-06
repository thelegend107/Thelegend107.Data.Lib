using MapDataReader;
using MySql.Data.MySqlClient;
using apiV2.Entities;
using apiV2.Helpers;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace apiV2.Services
{
    public class SkillService
    {
        private readonly MySqlConnection _sqlConnection;

        public SkillService(MySqlConnection MySqlConnection)
        {
            _sqlConnection = MySqlConnection;
        }

        public async Task<IEnumerable<Skill>> RetrieveSkills(int userId)
        {
            List<Skill> skills = new List<Skill>();

            string sql = ObjectToSQLHelper<Skill>.GenerateSelectQuery().ToString();

            using (MySqlConnection MySqlConnection = new MySqlConnection(_sqlConnection.ConnectionString))
            {
                MySqlConnection.Open();
                IDataReader dataReader = await new MySqlCommand(sql, MySqlConnection).ExecuteReaderAsync();
                skills = dataReader.ToSkill();
            }

            return skills;
        }
    }
}
