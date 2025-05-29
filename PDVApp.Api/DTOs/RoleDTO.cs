using PDVApp.Api.Models;

namespace PDVApp.Api.DTOs;

public class RoleDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; }
    public ICollection<User>? Users { get; set; } // Navigation property to the User entity
    public ICollection<string>? AccessibleEntities { get; set; } // List of entities the role can access
}
