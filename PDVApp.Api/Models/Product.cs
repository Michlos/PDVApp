namespace PDVApp.Api.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal SellingPrice { get; set; }
    public decimal BuyngPrice { get; set; }
    public int Quantity { get; set; }
    public int MinQuantity { get; set; }
    public string Barcode { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public Category? Category { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
    public bool Enabled { get; set; } = false;
    public decimal Margin
    {
        get
        {
            if (BuyngPrice == 0) return 0;
            return ((SellingPrice - BuyngPrice) / BuyngPrice) * 100;
        }
    }
}
