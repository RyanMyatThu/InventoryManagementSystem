using IMS.UseCases.Customers.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Customers
{
    public class RemoveCustomerUseCase : IRemoveCustomerUseCase
    {
        private ICustomerRepository _customerRepository;

        public RemoveCustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<int> ExecuteAsync(int customerId)
        {
            return await _customerRepository.RemoveCustomerAsync(customerId);   
        }
    }
}
