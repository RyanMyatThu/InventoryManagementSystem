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
    public class GetCustomerPriceItemsUseCase : IGetCustomerPriceItemsUseCase
    {
        ICustomerPriceRepository _customerPriceRepository;

        public GetCustomerPriceItemsUseCase(ICustomerPriceRepository customerPriceRepository)
        {
            _customerPriceRepository = customerPriceRepository;
        }

        public async Task<List<CustomerPrice>> ExecuteAsync(int customerId)
        {
            return await _customerPriceRepository.GetCustomerPriceItemsAsync(customerId);
        }
    }
}
