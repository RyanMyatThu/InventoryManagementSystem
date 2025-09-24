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
    public class AddCustomerUseCase : IAddCustomerUseCase
    {
        private ICustomerRepository _customerRepository;

        public AddCustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<int> ExecuteAsync(Customer customer)
        {
            return await _customerRepository.AddCustomerAsync(customer);
        }
    }
}
