using Microsoft.EntityFrameworkCore;
using Thelegend107.MySQL.Data.Lib.Entities;

namespace Thelegend107.MySQL.Data.Lib.Services
{
    public class CustomerService
    {
        private readonly DatawarehouseContext dbContext;

        public CustomerService(DatawarehouseContext DatawarehouseContext)
        {
            this.dbContext = DatawarehouseContext;
        }

        public async Task<Customer?> RetrieveCustomerByEmail(string email)
        {
            return await dbContext.Customers.SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Customer> CreateNewCustomer(Customer customer)
        {
            dbContext.Customers.Add(customer);
            await dbContext.SaveChangesAsync();
            
            return customer;
        }
    }
}
