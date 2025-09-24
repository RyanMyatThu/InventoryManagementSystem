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
    public class EFInventoryRepository : IInventoryRepository
    {

        private readonly IMSDbContext _db;

        public EFInventoryRepository(IMSDbContext db)
        {
            _db = db;
        }

        public async Task<int> AddInventoryAsync(Inventory inventory)
        {
            if (inventory == null) {
                throw new Exception("Invalid input (New inventory is null)");
            }
            _db.Inventories.Add(inventory);
            var res = await _db.SaveChangesAsync();
            return res;
        }

        public async Task<int> DeleteInventoryAsync(int id)
        {
            var product = await _db.Inventories.FirstOrDefaultAsync(x => x.InventoryId == id && !x.DeleteFlag) ?? throw new Exception("Item not found");

            product.DeleteFlag = true;

            var res = await _db.SaveChangesAsync();
            return res;

        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return await _db.Inventories.Where(x => !x.DeleteFlag).ToListAsync();

            var products = await _db.Inventories.Where(x => x.InventoryName == name && !x.DeleteFlag).ToListAsync();
            return products;
        }

        public async Task<Inventory?> GetInventoryByIdAsync(int id)
        {
            var product = await _db.Inventories.FirstOrDefaultAsync(x => x.InventoryId == id && !x.DeleteFlag);
            if(product == null) return null;

            return product;
        }

        public async Task<int> UpdateInventoryAsync(Inventory inventory)
        {
            if (inventory == null)
            {
                throw new Exception("Updated Inventory is null");
            }
            var existing = await _db.Inventories.FirstOrDefaultAsync(x => x.InventoryId == inventory.InventoryId && !x.DeleteFlag);
            if (existing == null)
            {
                throw new Exception("Updated Inventory is null");
            }
            ;
         
            existing.InventoryName = inventory.InventoryName;
            existing.Price = inventory.Price;

            var res = await _db.SaveChangesAsync();
            return res;

        }
    }
}
