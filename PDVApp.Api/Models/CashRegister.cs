namespace PDVApp.Api.Models;

public class CashRegister
{
    public int Id { get; set; }
    public DateTime RegisterDate { get; set; } = DateTime.UtcNow;
    public decimal InitialAmount { get; set; }
    public decimal FinalAmount { get; set; }
    public DateTime OpenedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ClosedAt { get; set; } // Nullable to indicate if the register is still open
    public int UserId { get; set; } // ID of the user who opened the register
    public User? User { get; set; } // Navigation property to the User entity
    public ICollection<Sale>? Sales { get; set; } // Navigation property to the Sale entity
    public decimal TotalCashIn { get; set; }
    public decimal TotalCashOut { get; set; }
    public decimal TotalSales { get; set; }
    public bool IsOpen { get; set; } = true; // Indicates if the cash register is currently open or closed


    //public ICollection<CashMovement>? CashMovements { get; set; } // Navigation property to the CashMovement entity
    //public ICollection<InventoryLog>? InventoryLogs { get; set; } // Navigation property to the InventoryLog entity
    //public decimal CashAmount { get; set; } // Amount of cash in the register
}
