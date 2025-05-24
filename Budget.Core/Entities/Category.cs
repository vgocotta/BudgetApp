namespace Budget.Core.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    public ICollection<Expense> Expenses { get; set; } = [];
}
