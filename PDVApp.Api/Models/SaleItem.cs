namespace PDVApp.Api.Models;

public class SaleItem
{
    public int Id { get; set; }
    public int SaleId { get; set; } // ID of the sale to which this item belongs
    public Sale? Sale { get; set; } // Navigation property to the Sale entity
    public int ProductId { get; set; } // ID of the product sold
    public Product? Product { get; set; } // Navigation property to the Product entity
    public decimal Price { get; set; } // Selling price of the product at the time of sale
    public int Quantity { get; set; } // Quantity of the product sold
    public decimal TotalPrice => Price * Quantity; // Total price for this item (Price * Quantity)
}