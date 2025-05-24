using Budget.Core.Entities;
using Budget.Core.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Budget.App.ViewModels.Expenses;

[QueryProperty(nameof(Expense), "expense")]
public partial class ExpenseDetailPageViewModel : ObservableObject
{

    [ObservableProperty]
    private ICollection<Category> categories = [];

    [ObservableProperty]
    private Expense expense = null!;

    private readonly ICategoryRepository _categoryRepository;
    private readonly IExpenseRepository _expenseRepository;

    public ExpenseDetailPageViewModel(IExpenseRepository expenseRepository, ICategoryRepository categoryRepository)
    {
        _expenseRepository = expenseRepository;
        _categoryRepository = categoryRepository;
    }


    [RelayCommand]
    private async Task LoadedPage()
    {
        var categories = await _categoryRepository.GetAllAsync();
        Categories = categories.ToList();
    }

    [RelayCommand]
    private async Task SaveChanges()
    {
        try
        {
            if (Expense.Id == 0)
            {
                await _expenseRepository.AddAsync(Expense);
            }
            else
            {
                await _expenseRepository.UpdateAsync(Expense);
            }
        }
        catch (Exception)
        {
        }
        finally
        {
            await Shell.Current.GoToAsync("..");
        }
    }

}
