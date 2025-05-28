
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
    public DbSet<CashRegister> CashRegisters { get; set; } = null!;
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


        modelBuilder.Entity<CashRegister>().ToTable("CashRegisters");
        modelBuilder.Entity<CashRegister>().HasKey(cr => cr.Id);
        modelBuilder.Entity<CashRegister>().Property(cr => cr.InitialAmount).HasPrecision(10, 2);
        modelBuilder.Entity<CashRegister>().Property(cr => cr.FinalAmount).HasPrecision(10, 2);
        modelBuilder.Entity<CashRegister>().Property(cr => cr.OpenedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        modelBuilder.Entity<CashRegister>().Property(cr => cr.ClosedAt).IsRequired(false);
        modelBuilder.Entity<CashRegister>().HasOne(cr => cr.User).WithMany(u => u.CashRegisters).HasForeignKey(cr => cr.UserId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<CashRegister>().HasMany(cr => cr.Sales).WithOne(il => il.CashRegister).HasForeignKey(il => il.CashRegisterId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<CashRegister>().Property(cr => cr.TotalCashIn).HasPrecision(10, 2);
        modelBuilder.Entity<CashRegister>().Property(cr => cr.TotalCashOut).HasPrecision(10, 2);
        modelBuilder.Entity<CashRegister>().Property(cr => cr.TotalSales).HasPrecision(10, 2);
        modelBuilder.Entity<CashRegister>().Property(cr => cr.IsOpen).HasDefaultValue(true);
        modelBuilder.Entity<CashRegister>().Property(cr => cr.RegisterDate).HasDefaultValueSql("CURRENT_TIMESTAMP");


        modelBuilder.Entity<Sale>().ToTable("Sales");
        modelBuilder.Entity<Sale>().HasKey(s => s.Id);
        modelBuilder.Entity<Sale>().Property(s => s.TotalAmount).HasPrecision(10, 2);
        modelBuilder.Entity<Sale>().Property(s => s.TotalDiscount).HasPrecision(10, 2);
        modelBuilder.Entity<Sale>().Property(s => s.SaleDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        modelBuilder.Entity<Sale>().HasOne(s => s.CashRegister).WithMany(cr => cr.Sales).HasForeignKey(s => s.CashRegisterId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Sale>().HasMany(s => s.SaleItems).WithOne(si => si.Sale).HasForeignKey(si => si.SaleId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Sale>().HasOne(s => s.User).WithMany(u => u.Sales).HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Sale>().Property(s => s.PaymentMethod).HasConversion<string>();
        modelBuilder.Entity<Sale>().HasOne(s => s.PaymentMethod).WithMany(pm => pm.Sales).HasForeignKey(s => s.PaymentMethodId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Sale>().Property(s => s.IsCanceled).HasDefaultValue(false);
        modelBuilder.Entity<Sale>().Property(s => s.SaleDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<SaleItem>().ToTable("SaleItems");
        modelBuilder.Entity<SaleItem>().HasKey(si => si.Id);
        modelBuilder.Entity<SaleItem>().Property(si => si.Quantity).IsRequired().HasDefaultValue(1);
        modelBuilder.Entity<SaleItem>().Property(si => si.Price).HasPrecision(10, 2);
        modelBuilder.Entity<SaleItem>().HasOne(si => si.Product).WithMany(p => p.SaleItems).HasForeignKey(si => si.ProductId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<SaleItem>().HasOne(si => si.Sale).WithMany(s => s.SaleItems).HasForeignKey(si => si.SaleId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<SaleItem>().Property(si => si.TotalPrice).HasPrecision(10, 2);
        modelBuilder.Entity<SaleItem>().HasOne(si => si.Product).WithMany(p => p.SaleItems).HasForeignKey(si => si.ProductId).OnDelete(DeleteBehavior.Restrict);


















        base.OnModelCreating(modelBuilder);
    }
}
