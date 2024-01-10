using Microsoft.EntityFrameworkCore;
using Thelegend107.Data.Lib.Entities;

namespace Thelegend107.Data.Lib.Services
{
    public class CustomerService
    {
        private readonly DatawarehouseContext dbContext;

        public CustomerService(DatawarehouseContext DatawarehouseContext)
        {
            this.dbContext = DatawarehouseContext;
        }

        public async Task<Customer?> RetrieveCustomer(int id)
        {
            return await dbContext.Customers.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Customer?> RetrieveCustomer(string email)
        {
            return await dbContext.Customers.SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Customer> CreateNewCustomer(Customer customer)
        {
            dbContext.Customers.Add(customer);
            await dbContext.SaveChangesAsync();
            
            return customer;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            Customer existingCustomer = await RetrieveCustomer(customer.Id);

            dbContext.Customers.Update(customer);
            await dbContext.SaveChangesAsync();

            return customer;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            Customer? customer = await RetrieveCustomer(id);
            
            if (customer != null)
            {
                dbContext.Remove(customer);
                await dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteCustomer(string email)
        {
            Customer? customer = await RetrieveCustomer(email);

            if (customer != null)
            {
                dbContext.Remove(customer);
                await dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
