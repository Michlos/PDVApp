using PDVApp.Api.Models;

namespace PDVApp.Api.DTOs;

public class InventoryLogDTO
{

    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int PreviousQuantity { get; set; }
    public int QuantityChanged { get; set; }
    public int CurrentQuantity { get; set; }
    public DateTime Timestamp { get; set; }
    public string? OriginType { get; set; }
    public int? OriginId { get; set; }
    public string? Action { get; set; }
    public int? UserId { get; set; }

}
