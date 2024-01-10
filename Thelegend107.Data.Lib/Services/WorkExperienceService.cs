using Microsoft.EntityFrameworkCore;
using System.Data;
using Thelegend107.Data.Lib.Entities;

namespace Thelegend107.Data.Lib.Services
{
    public class WorkExperienceService
    {
        private readonly DatawarehouseContext dbContext;

        public WorkExperienceService(DatawarehouseContext datawarehouseContext)
        {
            this.dbContext = datawarehouseContext;
        }

        public async Task<IEnumerable<WorkExperience>> RetrieveWorkExperiences(int userId)
        {
            List<WorkExperience> workExperiences = new List<WorkExperience>();
            workExperiences = await dbContext.WorkExperiences.Where(x => x.UserId == userId)
                .Include(x => x.Address).ThenInclude(x => x != null ? x.Country : null)
                .Include(x => x.Address).ThenInclude(x => x != null ? x.State : null)
                .Include(x => x.WorkExperienceItems)
                .ToListAsync();

            return workExperiences;
        }
    }
}
