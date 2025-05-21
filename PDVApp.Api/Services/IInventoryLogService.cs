using PDVApp.Api.DTOs;

namespace PDVApp.Api.Services;

public interface IInventoryLogService
{
    Task<IEnumerable<InventoryLogDTO>> GetInventoryLogs();
    Task<InventoryLogDTO> GetInventoryLogById(int id);
    Task<IEnumerable<InventoryLogDTO>> GetInventoryByProduct(int productId);
    Task AddInventoryLog(InventoryLogDTO inventoryLogDto);
    Task UpdateInventoryLog(InventoryLogDTO inventoryLogDto);
    Task RemoveInventoryLog(int id);
}
