using PDVApp.Api.Models;

namespace PDVApp.Api.DTOs;

public class CashRegisterDTO
{
    public int Id { get; set; }
    public DateTime RegisterDate { get; set; }
    public decimal InitialAmount { get; set; }
    public decimal FinalAmount { get; set; }
    public DateTime OpenedAt { get; set; }
    public DateTime? ClosedAt { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public ICollection<Sale>? Sales { get; set; }
    public decimal TotalCashIn { get; set; }
    public decimal TotalCashOut { get; set; }
    public decimal TotalSales { get; set; }
    public bool IsOpen { get; set; }
}
