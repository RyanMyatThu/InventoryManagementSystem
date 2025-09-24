using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.CustomerPrices.Interfaces
{
    public interface IAddCustomerPriceUseCase
    {
        Task<int> ExecuteAsync(IEnumerable<CustomerPrice> customerPrices);
        
    }
}
