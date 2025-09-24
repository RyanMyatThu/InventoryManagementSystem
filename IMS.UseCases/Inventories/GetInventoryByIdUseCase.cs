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
    public class GetInventoryByIdUseCase : IGetInventoryByIdUseCase
    {
        private readonly IInventoryRepository _inventoryRepository;

        public GetInventoryByIdUseCase(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;

        }
        public async Task<Inventory> ExecuteAsync(int id)
        {
            var item = await _inventoryRepository.GetInventoryByIdAsync(id);
            if (item == null)
            {
                throw new Exception("Product not found");
            }
            return item;


        }
    }
}
