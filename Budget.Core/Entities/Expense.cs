namespace Budget.Core.Entities;

public class Expense
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public bool IsPaid { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
