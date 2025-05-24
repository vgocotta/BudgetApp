using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Budget.App.Models;

public class BudgetValue : INotifyPropertyChanged
{
    private string _categoria = null!;
    private double _valor;
    public string Categoria { get => _categoria; set => SetField(ref _categoria, value); }
    public double Valor { get => _valor; set => SetField(ref _valor, value); }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null!) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    /// <summary>
    /// Este método realiza a alteração e a notificação da propriedade de forma genérica
    /// </summary>
    /// <typeparam name="T">Tipo da propriedade alterada</typeparam>
    /// <param name="field">Campo alterado</param>
    /// <param name="value">Novo valor do campo</param>
    /// <param name="propertyName">Nome da propriedade alterada</param>
    /// <returns></returns>
    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null!)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return true;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}