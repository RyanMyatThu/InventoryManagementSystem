using IMS.CoreBusiness;
using IMS.UseCases.CustomerPrices.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.CustomerPrices
{
    public class RemoveCustomerPricesUseCase : IRemoveCustomerPricesUseCase
    {
        ICustomerPriceRepository _customerPriceRepository;
        public RemoveCustomerPricesUseCase(ICustomerPriceRepository customerPriceRepository)
        {
            _customerPriceRepository = customerPriceRepository;
        }
        public async Task<int> ExecuteAsync(IEnumerable<CustomerPrice> customerPrices)
        {
            return await _customerPriceRepository.RemoveCustomerPricesAsync(customerPrices);
        }
    }
}
