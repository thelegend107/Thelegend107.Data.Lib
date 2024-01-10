using Microsoft.EntityFrameworkCore;
using System.Data;
using Thelegend107.Data.Lib.Entities;

namespace Thelegend107.Data.Lib.Services
{
    public class LinkService
    {
        private readonly DatawarehouseContext dbContext;

        public LinkService(DatawarehouseContext datawarehouseContext)
        {
            this.dbContext = datawarehouseContext;
        }

        public async Task<IEnumerable<Link>> RetrieveLinks(int userId)
        {
            List<Link> links = new List<Link>();
            links = await dbContext.Links.Where(x => x.UserId == userId).ToListAsync();
            return links;
        }
    }
}
