using IMS.CoreBusiness;

namespace IMS.UseCases.Customers.Interfaces
{
    public interface IGetCustomerAndInventoryUseCase
    {
        Task<IEnumerable<(Inventory Inventory, decimal SellPrice)>> ExecuteAsync(int customerId);
    }
}
