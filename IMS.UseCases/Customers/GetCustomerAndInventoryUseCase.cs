using IMS.CoreBusiness;
using IMS.UseCases.Customers.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Customers
{
    public class GetCustomerAndInventoryUseCase : IGetCustomerAndInventoryUseCase
    {
        private ICustomerRepository _customerRepository;

        public GetCustomerAndInventoryUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<(Inventory Inventory, decimal SellPrice)>> ExecuteAsync(int customerId)
        {
            return await _customerRepository.GetInventoriesByCustomerAsync(customerId);
        }
    }
}
