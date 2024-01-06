using MapDataReader;
using Microsoft.Data.SqlClient;
using ResumeAPI.Entities;
using ResumeAPI.Helpers;
using System.Data;

namespace ResumeAPI.Services
{
    public class SkillService
    {
        private readonly SqlConnection _sqlConnection;

        public SkillService(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<IEnumerable<Skill>> RetrieveSkills(int userId)
        {
            List<Skill> skills = new List<Skill>();

            string sql = ObjectToSQLHelper<Skill>.GenerateSelectQuery().ToString();

            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnection.ConnectionString))
            {
                sqlConnection.Open();
                IDataReader dataReader = await new SqlCommand(sql, sqlConnection).ExecuteReaderAsync();
                skills = dataReader.ToSkill();
            }

            return skills;
        }
    }
}
