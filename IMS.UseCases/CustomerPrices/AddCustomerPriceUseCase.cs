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
    public class AddCustomerPriceUseCase : IAddCustomerPriceUseCase
    {
        private ICustomerPriceRepository _customerPriceRepository;

        public AddCustomerPriceUseCase(ICustomerPriceRepository customerPriceRepository)
        {
            _customerPriceRepository = customerPriceRepository;
        }
        public async Task<int> ExecuteAsync(IEnumerable<CustomerPrice> customerPrices)
        {
            return await _customerPriceRepository.AddCustomerPriceAsync(customerPrices);
        }
    }
}
