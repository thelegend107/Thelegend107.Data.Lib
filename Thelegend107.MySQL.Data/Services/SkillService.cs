using Microsoft.EntityFrameworkCore;
using System.Data;
using Thelegend107.MySQL.Data.Lib.Entities;

namespace Thelegend107.MySQL.Data.Lib.Services
{
    public class SkillService
    {
        private readonly DatawarehouseContext dbContext;

        public SkillService(DatawarehouseContext datawarehouseContext)
        {
            this.dbContext = datawarehouseContext;
        }

        public async Task<IEnumerable<Skill>> RetrieveSkills(int userId)
        {
            List<Skill> skills = new List<Skill>();
            skills = await dbContext.Skills.Where(x => x.UserId == userId).ToListAsync();
            return skills;
        }
    }
}
