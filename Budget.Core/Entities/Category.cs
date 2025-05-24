using Budget.Core.Tools;

namespace Budget.Core.Entities;

public class Category : NotifyPropertyChanged
{
    private int id;
    private string name = default!;

    public int Id { get => id; set => SetField(ref id, value); }
    public string Name { get => name; set => SetField(ref name, value); }

    public ICollection<Expense> Expenses { get; set; } = [];
}
