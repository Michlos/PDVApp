using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PDVApp.Api.DTOs;
using PDVApp.Api.Services;

namespace PDVApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InventoryLogController : ControllerBase
{
    private readonly IInventoryLogService _inventoryLogService;
    public InventoryLogController(IInventoryLogService inventoryLogService)
    {
        _inventoryLogService = inventoryLogService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<InventoryLogDTO>>> Get()
    {
        var inventoryLogsDto = await _inventoryLogService.GetInventoryLogs();
        if (inventoryLogsDto is null)
            return NotFound("No inventory logs found.");
        return Ok(inventoryLogsDto);
    }

    [HttpGet("product")]
    public async Task<ActionResult<IEnumerable<InventoryLogDTO>>> GetInventoryByProduct(int productId)
    {
        var inventoryLogsDto = await _inventoryLogService.GetInventoryByProduct(productId);
        if (inventoryLogsDto is null)
            return NotFound("No inventory logs found.");
        return Ok(inventoryLogsDto);
    }

}
