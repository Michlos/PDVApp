
using Microsoft.EntityFrameworkCore;

using PDVApp.Api.Models;

namespace PDVApp.Api.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<InventoryLog> InventoryLogs { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().ToTable("Products");
        modelBuilder.Entity<Product>().HasKey(p => p.Id);
        modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Product>().Property(p => p.Description).HasMaxLength(500);
        modelBuilder.Entity<Product>().Property(p => p.BuyngPrice).HasPrecision(10, 2);
        modelBuilder.Entity<Product>().Property(p => p.SellingPrice).HasPrecision(10, 2);
        modelBuilder.Entity<Product>().Property(p => p.Quantity).IsRequired().HasDefaultValue(0);



        modelBuilder.Entity<Category>().ToTable("Categories");
        modelBuilder.Entity<Category>().HasKey(c => c.Id);
        modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Category>().HasMany(c => c.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<InventoryLog>().ToTable("InventoryLogs");
        modelBuilder.Entity<InventoryLog>().Property(e => e.OriginType).HasConversion<string>();
        modelBuilder.Entity<InventoryLog>().Property(e => e.Action).HasConversion<string>();

        


        base.OnModelCreating(modelBuilder);
    }
}
