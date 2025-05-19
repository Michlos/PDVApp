using PDVApp.Api.Models;

using System.ComponentModel.DataAnnotations;

namespace PDVApp.Api.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage ="The Name is Required")]
    [MinLength(3, ErrorMessage = "The Name must have at least 3 characters")]
    [MaxLength(100, ErrorMessage = "The Name must have at most 100 characters")]
    public string Name { get; set; } = string.Empty;
    public ICollection<Product>? Products { get; set; }
}
