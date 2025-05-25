namespace PDVApp.Api.Models;

public class PaymentMethod
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; // e.g., Cash, Credit Card, Debit Card, etc.
    //public string Description { get; set; }

}
