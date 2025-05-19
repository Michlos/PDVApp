using Microsoft.EntityFrameworkCore;

using PDVApp.Api.Context;
using PDVApp.Api.Models;

using System.Globalization;

namespace PDVApp.Api.Repository;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetById(int id)
    {
        return await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Product> Create(Product product)
    {
        _context.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }
    public async Task<Product> Update(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> Delete(int id)
    {
        var product = await GetById(id);
        if (product == null) return null!;
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return product;
    }

}
