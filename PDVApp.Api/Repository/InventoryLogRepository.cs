using Microsoft.EntityFrameworkCore;

using PDVApp.Api.Context;
using PDVApp.Api.Models;

namespace PDVApp.Api.Repository;

public class InventoryLogRepository : IInventoryLogRepository
{
    private readonly AppDbContext _context;

    public InventoryLogRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<InventoryLog>> GetAll()
    {
        return await _context.InventoryLogs.ToListAsync();
    }
    public async Task<InventoryLog?> GetById(int id)
    {
        return await _context.InventoryLogs.Where(c => c.Id == id).FirstOrDefaultAsync();
    }
    
    public async Task<InventoryLog> Create(InventoryLog inventoryLog)
    {
        _context.Add(inventoryLog);
        await _context.SaveChangesAsync();
        return inventoryLog;
    }
    public async Task<InventoryLog> Update(InventoryLog inventoryLog)
    {
        _context.Entry(inventoryLog).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return inventoryLog;
    }

    public async Task<InventoryLog> Delete(int id)
    {
        var inventoryLog = await GetById(id);
        if (inventoryLog == null) return null!;
        _context.InventoryLogs.Remove(inventoryLog);
        await _context.SaveChangesAsync();
        return inventoryLog;
    }

    public async Task<IEnumerable<InventoryLog>> GetInventoryByProduct(int productId)
    {
        return await _context.InventoryLogs.Include(c => c.Product).Where(c => c.ProductId == productId).ToListAsync();
    }
}
