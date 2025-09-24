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
    public class GetCustomerByIdUseCase : IGetCustomerByIdUseCase
    {
        ICustomerRepository _customerRepository;
        public GetCustomerByIdUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> ExecuteAsync(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null) {
                throw new Exception("Customer not found");
            }
            return customer;
        }
    }
}
