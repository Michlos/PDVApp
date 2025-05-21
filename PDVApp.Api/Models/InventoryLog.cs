namespace PDVApp.Api.Models;

public class InventoryLog
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int PreviousQuantity { get; set; }
    public int QuantityChanged { get; set; }
    public int CurrentQuantity { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public OriginType OriginType { get; set; } // e.g., Sale, Purchase, Adjustment, Transfer
    public int? OriginId { get; set; } //e.g. SaleId, PurschaseId, AdjustmentId, TransferId
    public Action Action { get; set; } // e.g., Added, Removed
    public int? UserId { get; set; } // ID of the user who made the change
}

public enum OriginType
{
    Sale,
    Purchase,
    Adjustment,
    Transfer
}

public enum Action
{
    Added,
    Removed
}
