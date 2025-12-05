using IMS.UseCases.CustomerPrices.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.CustomerPrices
{
    public class CheckForInventoryItemUseCase : ICheckForInventoryItemUseCase
    {
        private ICustomerPriceRepository _customerPriceRepository;

        public CheckForInventoryItemUseCase(ICustomerPriceRepository customerPriceRepository)
        {
            _customerPriceRepository = customerPriceRepository;
        }
        public async Task<bool> ExecuteAsync(int inventoryId)
        {
            return await _customerPriceRepository.CheckForInventoryItemAsync(inventoryId);
        }
    }
}
