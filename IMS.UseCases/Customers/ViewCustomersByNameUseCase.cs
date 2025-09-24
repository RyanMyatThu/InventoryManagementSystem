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
    public class ViewCustomersByNameUseCase : IViewCustomersByNameUseCase
    {
        private ICustomerRepository _customerRepository;
        public ViewCustomersByNameUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> ExecuteAsync(string name = "")
        {
            return await _customerRepository.GetCustomersByName(name);
        }
    }
}
