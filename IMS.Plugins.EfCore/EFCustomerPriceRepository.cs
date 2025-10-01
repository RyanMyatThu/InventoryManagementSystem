using IMS.CoreBusiness;
using IMS.Plugins.EfCore;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore
{
    public class EFCustomerPriceRepository : ICustomerPriceRepository
    {
        private readonly IMSDbContext _db;

        public EFCustomerPriceRepository(IMSDbContext db)
        {
            _db = db;
        }
        public async Task<int> AddCustomerPriceAsync(IEnumerable<CustomerPrice> customerPrices)
        {
            if (customerPrices == null || !customerPrices.Any())
                throw new ArgumentException("No customer prices provided");

            await _db.CustomerPrices.AddRangeAsync(customerPrices);
            return await _db.SaveChangesAsync();
        }

        public async Task<List<CustomerPrice>> GetCustomerPriceItemsAsync(int customerId)
        {
            if (customerId == 0) throw new Exception("Customer Id cannot be 0");

            var items = await _db.CustomerPrices
                                    .Include(cp => cp.Inventory)
                                    .Where(c => c.CustomerId == customerId)
                                    .ToListAsync();
            return items;
        }
       
        public async Task<int> UpdateCustomerPriceAsync()
        {
            int res = await _db.SaveChangesAsync();
            return res;
        }

        public async Task<int> RemoveCustomerPricesAsync(IEnumerable<CustomerPrice> customerPrices)
        {
            if (customerPrices == null || !customerPrices.Any())
                throw new ArgumentException("No customer prices provided");
            _db.CustomerPrices.RemoveRange(customerPrices);
            return await _db.SaveChangesAsync();

        }

        public async Task<int> RemoveCustomerPriceAsync(int customerId, int inventoryId)
        {
            if (customerId == 0) throw new Exception("Customer Id cannot be 0");
            if (inventoryId == 0) throw new Exception("Inventory Id cannot be 0");
            var customer = await _db.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);
            if (customer == null) throw new Exception("Customer not found");

            var cp = await _db.CustomerPrices.FirstOrDefaultAsync(cp => cp.CustomerId == customerId && cp.InventoryId == inventoryId);
            if (cp == null) throw new Exception("Cannot find item to remove");
             _db.Remove(cp);
            customer.TotalItems--;
            int res = await _db.SaveChangesAsync();
            return res;
        }

        public async Task<int> AddCustomerPriceItemAsync(int customerId, int inventoryId)
        {
            if (customerId == 0) throw new Exception("Customer Id cannot be 0");
            if (inventoryId == 0) throw new Exception("Inventory Id cannot be 0");

            var customer = await _db.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);
            if (customer == null) throw new Exception("Customer not found");

            CustomerPrice newCp = new CustomerPrice()
            {
                CustomerId = customerId,
                InventoryId = inventoryId,
                SellPrice = 0
            };
            await _db.AddAsync(newCp);
            customer.TotalItems++;
            return await _db.SaveChangesAsync();

        }
    }
}
