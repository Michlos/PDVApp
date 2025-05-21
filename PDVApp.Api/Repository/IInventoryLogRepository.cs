using PDVApp.Api.Models;

namespace PDVApp.Api.Repository;

public interface IInventoryLogRepository
{
    Task<InventoryLog?> GetById(int id);
    Task<IEnumerable<InventoryLog>> GetAll();
    Task<IEnumerable<InventoryLog>> GetInventoryByProduct(int productId);
    Task<InventoryLog> Create(InventoryLog inventoryLog);
    Task<InventoryLog> Update(InventoryLog inventoryLog);
    Task<InventoryLog> Delete(int id);
}
