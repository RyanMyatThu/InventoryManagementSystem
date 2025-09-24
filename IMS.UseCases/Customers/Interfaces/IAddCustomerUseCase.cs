using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Customers.Interfaces
{
    public interface IAddCustomerUseCase
    {
        Task<int> ExecuteAsync(Customer customer);
    }
}
