using IMS.CoreBusiness;


namespace IMS.UseCases.Customers.Interfaces
{
    public interface IViewCustomersByNameUseCase
    {
        Task<IEnumerable<Customer>> ExecuteAsync(string name = "");

    }
}
