using Microsoft.EntityFrameworkCore;
using System.Data;
using Thelegend107.MySQL.Data.Lib.Entities;

namespace Thelegend107.MySQL.Data.Lib.Services
{
    public class CertificateService
    {
        private readonly DatawarehouseContext dbContext;

        public CertificateService(DatawarehouseContext DatawarehouseContext)
        {
            this.dbContext = DatawarehouseContext;
        }

        public async Task<IEnumerable<Certificate>> RetrieveCertifcates(int userId)
        {
            List<Certificate> certificates = new List<Certificate>();
            certificates = await dbContext.Certificates.Where(x => x.UserId == userId).ToListAsync();
            return certificates;
        }
    }
}
