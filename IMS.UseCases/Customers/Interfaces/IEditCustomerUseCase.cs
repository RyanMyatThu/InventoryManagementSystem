using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Customers.Interfaces
{
    public interface IEditCustomerUseCase
    {
        Task<int> ExecuteAsync(Customer customer);
    }
}
