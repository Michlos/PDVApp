using PDVApp.Api.Models;

using System.ComponentModel.DataAnnotations;

namespace PDVApp.Api.DTOs;

public class ProductDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3, ErrorMessage = "The Name must have at least 3 characters")]
    [MaxLength(100, ErrorMessage = "The Name must have at most 100 characters")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The Description is Required")]
    [MinLength(3, ErrorMessage = "The Name must have at least 3 characters")]
    [MaxLength(500, ErrorMessage = "The Name must have at most 100 characters")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "The Selling Price is Required")]
    [Range(0.01, 9999999999.99, ErrorMessage = "The Selling Price must be greater than 0")]
    public decimal SellingPrice { get; set; }

    [Required(ErrorMessage = "The Buying Price is Required")]
    [Range(0.01, 9999999999.99, ErrorMessage = "The Buying Price must be greater than 0")]
    public decimal BuyngPrice { get; set; }

    [Required(ErrorMessage = "The Quantity is Required")]
    [Range(0, 9999999999, ErrorMessage = "The Quantity must be greater than or equal to 0")]
    public int Quantity { get; set; }
    public string? ImageUrl { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
