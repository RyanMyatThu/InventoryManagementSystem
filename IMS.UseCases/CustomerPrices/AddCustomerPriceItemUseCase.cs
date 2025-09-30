using IMS.UseCases.CustomerPrices.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.CustomerPrices
{
    public class AddCustomerPriceItemUseCase : IAddCustomerPriceItemUseCase
    {
        private ICustomerPriceRepository _customerPriceRepository;
        public AddCustomerPriceItemUseCase(ICustomerPriceRepository customerPriceRepository)
        {
            _customerPriceRepository = customerPriceRepository;
        }
        public async Task<int> ExecuteAsync(int customerId, int inventoryId)
        {
            return await _customerPriceRepository.AddCustomerPriceItemAsync(customerId, inventoryId);
        }
    }
}
