using PDVApp.Api.Models;

namespace PDVApp.Api.DTOs;

public class SaleDTO
{
    public int Id { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal TotalDiscount { get; set; } // Total discount applied to the sale
    public decimal TotalAmount { get; set; }
    public int CashRegisterId { get; set; } // ID of the cash register where the sale was made
    public CashRegister? CashRegister { get; set; } // Navigation property to the CashRegister entity
    public ICollection<SaleItem>? SaleItems { get; set; } // Navigation property to the SaleItem entity
    public int UserId { get; set; } // ID of the user who made the sale
    public User? User { get; set; } // Navigation property to the User entity
    public int PaymentMethodId { get; set; }
    public PaymentMethod? PaymentMethod { get; set; } // Navigation property to the PaymentMethod entity
    public bool IsCanceled { get; set; }
}
