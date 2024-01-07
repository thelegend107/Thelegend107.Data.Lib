using Microsoft.EntityFrameworkCore;
using Thelegend107.MySQL.Data.Lib.Entities;

namespace Thelegend107.MySQL.Data.Lib.Services
{
    public class AddressService
    {
        private readonly DatawarehouseContext dbcontext;

        public AddressService(DatawarehouseContext datawarehouseContext)
        {
            this.dbcontext = datawarehouseContext;
        }

        public async Task<Address?> RetrieveAddressById(int? id)
        {
            Address? address = await dbcontext.Addresses
                .Include(x => x.Country)
                .Include(x => x.State)
                .SingleOrDefaultAsync(x => x.Id == id);
            return address;
        }
    }
}
