using AutoMapper;

using PDVApp.Api.DTOs;
using PDVApp.Api.Models;
using PDVApp.Api.Repository;

namespace PDVApp.Api.Services;

public class InventoryLogService : IInventoryLogService
{
    private readonly IInventoryLogRepository _inventoryLogRepository;
    private readonly IMapper _mapper;
    public InventoryLogService(IInventoryLogRepository inventoryLogRepository, IMapper mapper)
    {
        _inventoryLogRepository = inventoryLogRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<InventoryLogDTO>> GetInventoryLogs()
    {
        var inventoryLogEntity = await _inventoryLogRepository.GetAll();
        return _mapper.Map<IEnumerable<InventoryLogDTO>>(inventoryLogEntity);
    }
    public async Task<InventoryLogDTO> GetInventoryLogById(int id)
    {
        var inventoryLogEntity = await _inventoryLogRepository.GetById(id);
        if (inventoryLogEntity == null) return null!;
        return _mapper.Map<InventoryLogDTO>(inventoryLogEntity);
    }
    public async Task<IEnumerable<InventoryLogDTO>> GetInventoryByProduct(int productId)
    {
        var inventoryLogs = await _inventoryLogRepository.GetInventoryByProduct(productId);
        return _mapper.Map<IEnumerable<InventoryLogDTO>>(inventoryLogs);
    }
    public async Task AddInventoryLog(InventoryLogDTO inventoryLogDto)
    {
        var inventoryLogEntity = _mapper.Map<InventoryLog>(inventoryLogDto);
        await _inventoryLogRepository.Create(inventoryLogEntity);
        inventoryLogDto.Id = inventoryLogEntity.Id;
    }
    public async Task UpdateInventoryLog(InventoryLogDTO inventoryLogDto)
    {
        var inventoryLogEntity = _mapper.Map<InventoryLog>(inventoryLogDto);
        await _inventoryLogRepository.Update(inventoryLogEntity);
    }
    public async Task RemoveInventoryLog(int id)
    {
        var inventorylogEntity = await _inventoryLogRepository.GetById(id);
        if (inventorylogEntity == null) return;
        await _inventoryLogRepository.Delete(id);
    }
}
