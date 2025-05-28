namespace PDVApp.Api.DTOs;

public class SaleItemDTO
{
    public int Id { get; set; } // Unique identifier for the sales item
    public int SaleId { get; set; } // ID of the sale this item belongs to
    public SaleDTO? Sale { get; set; } // Navigation property to the Sale entity
    public int ProductId { get; set; } // ID of the product sold
    public ProductDTO? Product { get; set; } // Navigation property to the Product entity
    public decimal Price { get; set; } // Price of the product at the time of sale
    public decimal Quantity { get; set; } // Quantity of the product sold
    public decimal TotalPrice { get; set; } // Total price for this sales item (Price * Quantity)
}
