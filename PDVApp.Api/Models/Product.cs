﻿namespace PDVApp.Api.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal SellingPrice { get; set; }
    public decimal BuyngPrice { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public Category? Category { get; set; } = null!;
}
