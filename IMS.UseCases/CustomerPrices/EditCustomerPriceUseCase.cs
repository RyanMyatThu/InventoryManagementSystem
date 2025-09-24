using IMS.UseCases.CustomerPrices.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.CustomerPrices
{
    public class EditCustomerPriceUseCase : IEditCustomerPriceUseCase
    {
        private ICustomerPriceRepository _customerPriceRepository;

        public EditCustomerPriceUseCase(ICustomerPriceRepository customerPriceRepository)
        {
            _customerPriceRepository = customerPriceRepository;
        }

        public async Task<int> ExecuteAsync()
        {
            return await _customerPriceRepository.UpdateCustomerPriceAsync();
        }

    
    }
}
