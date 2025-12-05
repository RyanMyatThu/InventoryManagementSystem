using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.PluginInterfaces
{
    public interface ICustomerPriceRepository
    {

        Task<int> AddCustomerPriceAsync(IEnumerable<CustomerPrice> customerPrice);

        Task<int> UpdateCustomerPriceAsync();

        Task<List<CustomerPrice>> GetCustomerPriceItemsAsync(int customerId);

        Task<int> RemoveCustomerPriceAsync(int customerId, int inventoryId);

        Task<int> AddCustomerPriceItemAsync(int customerId, int inventoryId);

        Task<int> RemoveCustomerPricesAsync(IEnumerable<CustomerPrice> customerPrices);

        Task<bool> CheckForInventoryItemAsync(int inventoryId);

    }
}
