using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Inventories.Interfaces
{
    public interface IAddInventoryUseCase
    {
        Task<int> ExecuteAsync(Inventory inventory);
    }
}
