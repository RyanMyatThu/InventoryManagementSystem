using IMS.CoreBusiness;
using IMS.Plugins.EfCore;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;


namespace IMS.Plugins.EFCore
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private readonly IMSDbContext _db;

        public EFCustomerRepository(IMSDbContext db)
        {
            _db = db;
        }
        public async Task<int> AddCustomerAsync(Customer customer)
        {
            if(customer == null)
            {
                throw new Exception("Invalid input (New Customer Is Null)");
            }
            _db.Add(customer);
           await _db.SaveChangesAsync();

            return customer.CustomerId;
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            var customer = await _db.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
            if (customer == null) return null;
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomersByName(string name)
        {
            var query = _db.Customers.Include(c => c.CustomerPrices).ThenInclude(cp => cp.Inventory);

            if (string.IsNullOrWhiteSpace(name)) return await query.ToListAsync();

            var customer = await query.Where(x => x.CustomerName == name).ToListAsync();
            return customer;
        }

        public async Task<IEnumerable<(Inventory Inventory, decimal SellPrice)>> GetInventoriesByCustomerAsync(int customerId)
        {
            if(customerId <= 0)
            {
                throw new Exception("Invalid ID");
            }
            var customer = await _db.Customers
                .Include(c => c.CustomerPrices).ThenInclude(cp => cp.Inventory).FirstOrDefaultAsync(c => c.CustomerId == customerId) ?? throw new Exception("Customer data not found");
            return customer.CustomerPrices
                .Select(cp => (cp.Inventory, cp.SellPrice))
                .ToList();
        }

        public async Task<int> UpdateCustomerAsync(Customer customer)
        {
            if(customer == null)
            {
                throw new Exception("Updated customer is null");
            }
            var existing = await _db.Customers.FirstOrDefaultAsync(x => x.CustomerId == customer.CustomerId);
            if(existing == null)
            {
                throw new Exception("Customer not found");
            }
            existing.CustomerName = customer.CustomerName;
            existing.Phone = customer.Phone;
            existing.Address = customer.Address;

            var res = await _db.SaveChangesAsync();
            return res;
        }
    }
}
