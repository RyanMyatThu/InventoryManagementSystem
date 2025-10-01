using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.PluginInterfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomersByName(string name);
        Task<Customer?> GetCustomerById(int id);

        Task<int> AddCustomerAsync(Customer customer);

        Task<int> UpdateCustomerAsync(Customer customer);

        Task<IEnumerable<(Inventory Inventory, decimal SellPrice)>> GetInventoriesByCustomerAsync(int customerId);
        Task<int> RemoveCustomerAsync(int customerId);

    }
}
