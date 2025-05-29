using PDVApp.Api.Models;

namespace PDVApp.Api.DTOs;

public class UserDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; } = true;
    public int RoleId { get; set; } // e.g., Admin, Cashier, Manager
    public Role? Role { get; set; } // Navigation property to the Role entity
    public ICollection<CashRegister>? CashRegisters { get; set; } // Navigation property to the CashRegister entity
    public ICollection<Sale>? Sales { get; set; } // Navigation property to the Sale entity
}
