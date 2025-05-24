using Budget.Core.Tools;

namespace Budget.App.Models;

public class BudgetValue : NotifyPropertyChanged
{
    private string _categoria = null!;
    private decimal _valor;
    public string Categoria { get => _categoria; set => SetField(ref _categoria, value); }
    public decimal Valor { get => _valor; set => SetField(ref _valor, value); }

}