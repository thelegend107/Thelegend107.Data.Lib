using Microsoft.EntityFrameworkCore;
using System.Data;
using Thelegend107.Data.Lib.Entities;

namespace Thelegend107.Data.Lib.Services
{
    public class EducationService
    {
        private readonly DatawarehouseContext dbContext;

        public EducationService(DatawarehouseContext datawarehouseContext)
        {
            this.dbContext = datawarehouseContext;
        }

        public async Task<IEnumerable<Education>> RetrieveEducations(int userId)
        {
            List<Education> educations = new List<Education>();
            educations = await dbContext.Educations.Where(x => x.UserId == userId)
                .Include(x => x.Address).ThenInclude(x => x != null ? x.Country : null)
                .Include(x => x.Address).ThenInclude(x => x != null ? x.State : null)
                .Include(x => x.EducationItems)
                .ToListAsync();

            return educations;
        }
    }
}
