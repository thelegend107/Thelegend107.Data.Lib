using MapDataReader;
using Microsoft.Data.SqlClient;
using System.Data;
using Thelegend107.SQL.Data.Lib.Entities;
using Thelegend107.SQL.Data.Lib.Helpers;

namespace Thelegend107.SQL.Data.Lib.Services
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
