using Microsoft.EntityFrameworkCore;
using Thelegend107.MySQL.Data.Lib.Entities;

namespace Thelegend107.MySQL.Data.Lib.Services
{
    public class UserService
    {
        private readonly DatawarehouseContext dbContext;

        public UserService(DatawarehouseContext datawarehouseContext)
        {
            this.dbContext = datawarehouseContext;
        }

        public async Task<User?> RetrieveUserById(int? Id)
        {
            User? user = await dbContext.Users.SingleOrDefaultAsync(x => x.Id == Id);
            return user;
        }

        public async Task<User?> RetrieveUserByEmail(string email)
        {
            User? user = await dbContext.Users.SingleOrDefaultAsync(x => x.Email == email);
            return user;
        }
    }
}
