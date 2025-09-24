using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Inventories
{
    public class DeleteInventoryUseCase : IDeleteInventoryUseCase
    {
        private IInventoryRepository _inventoryRepository;
        public DeleteInventoryUseCase(IInventoryRepository inventoryRepository) { 

            _inventoryRepository = inventoryRepository;
        
        }
        public async Task<int> ExecuteAsync(int id)
        {
            return await _inventoryRepository.DeleteInventoryAsync(id);
        }
    }
}
