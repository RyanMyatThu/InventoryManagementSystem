using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.CustomerPrices.Interfaces
{
    public interface IRemoveCustomerPriceUseCase
    {
        Task<int> ExecuteAsync(int customerId, int inventoryId);
    }
}
