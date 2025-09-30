using IMS.UseCases.CustomerPrices.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.CustomerPrices
{
    public class RemoveCustomerPriceUseCase : IRemoveCustomerPriceUseCase
    {
        private ICustomerPriceRepository _customerPriceRepository;

        public RemoveCustomerPriceUseCase(ICustomerPriceRepository customerPriceRepository)
        {
            _customerPriceRepository = customerPriceRepository;
        }

        public async Task<int> ExecuteAsync(int customerId, int inventoryId)
        {
           return await _customerPriceRepository.RemoveCustomerPriceAsync(customerId, inventoryId);
        }
    }
}
