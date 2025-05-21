namespace PDVApp.Api.Models;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
    public ICollection<User>? Users { get; set; } // Navigation property to the User entity
    public ICollection<string>? AccessibleEntities { get; set; } // List of entities the role can access
}