using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name);
        Task<Inventory?> GetInventoryByIdAsync(int id);

        Task<int> AddInventoryAsync(Inventory inventory);

        Task<int> UpdateInventoryAsync(Inventory inventory);

        Task<int> DeleteInventoryAsync(int id);
    }
}
