

using IMS.CoreBusiness;

namespace IMS.UseCases.Customers.Interfaces
{
    public interface IGetCustomerByIdUseCase
    {
        Task<Customer> ExecuteAsync(int id);
    }
}
