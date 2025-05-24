using Budget.Core.Tools;

namespace Budget.Core.Entities;

public class Expense : NotifyPropertyChanged
{
    private int id;
    private string description = string.Empty;
    private decimal amount;
    private DateTime date;
    private bool isPaid;
    private int categoryId;
    private Category? category;

    public int Id { get => id; set => SetField(ref  id, value); }
    public string Description { get => description; set => SetField(ref  description, value); }
    public decimal Amount { get => amount; set => SetField(ref  amount, value); }
    public DateTime Date { get => date; set => SetField(ref  date, value); }
    public bool IsPaid { get => isPaid; set => SetField(ref  isPaid, value); }

    public int CategoryId { get => categoryId; set => SetField(ref  categoryId, value); }
    public Category? Category { get => category; set => SetField(ref  category, value); }
}
