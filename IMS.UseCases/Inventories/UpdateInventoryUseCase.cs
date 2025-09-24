using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Inventories
{
    public class UpdateInventoryUseCase : IUpdateInventoryUseCase
    {
        private IInventoryRepository _inventoryRepository;
        public UpdateInventoryUseCase(IInventoryRepository inventoryRepository) { 
            
            _inventoryRepository = inventoryRepository;

        }
        public async Task<int> ExecuteAsync(Inventory inventory)
        {
           return await _inventoryRepository.UpdateInventoryAsync(inventory);
        }
    }
}
