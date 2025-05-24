using Budget.Core.Entities;
using Budget.Core.Interfaces;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Budget.App.ViewModels.Expenses;

public partial class ExpensesPageViewModel : ObservableObject
{

    [ObservableProperty]
    private ICollection<Expense> _expenses = [];

    [ObservableProperty]
    private Expense? _selectedExpense = null!;

    private readonly IExpenseRepository _expenseRepository;

    public ExpensesPageViewModel(IExpenseRepository expenseRepository)
    {
        _expenseRepository = expenseRepository;
    }

    [RelayCommand]
    private async Task LoadedPage()
    {
        var expenses = await _expenseRepository.GetAllAsync();
        Expenses = expenses.ToObservableCollection();
    }

    [RelayCommand]
    private async Task AddNew()
    {
        Dictionary<string, object> parameters = new()
            {
                { "expense", new Expense() {Date = DateTime.Now } }
            };
        await Shell.Current.GoToAsync("ExpenseDetail", true, parameters);
    }

    [RelayCommand]
    private async Task OnSelectionChanged()
    {
        if (SelectedExpense == null)
        {
            return;
        }

        var result = await Application.Current!.MainPage!.DisplayActionSheet("O que deseja fazer?", null, null, FlowDirection.MatchParent, "Editar", "Excluir", "Cancelar");

        if (result == "Editar")
        {
            Dictionary<string, object> parameters = new()
            {
                { "expense", SelectedExpense }
            };
            await Shell.Current.GoToAsync("ExpenseDetail", true, parameters);
        }
        else if (result == "Excluir")
        {
            await DeleteSelected();
        }
    }

    private async Task DeleteSelected()
    {
        if (SelectedExpense == null)
        {
            return;
        }
        await _expenseRepository.DeleteAsync(SelectedExpense.Id);
        Expenses.Remove(SelectedExpense);
    }
}
