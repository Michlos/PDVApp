namespace PDVApp.Api.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
    public int RoleId { get; set; } // e.g., Admin, Cashier, Manager
    public Role? Role { get; set; } // Navigation property to the Role entity
    public ICollection<CashRegister>? CashRegisters { get; set; } // Navigation property to the CashRegister entity
    public ICollection<Sale>? Sales { get; set; } // Navigation property to the Sale entity
}
