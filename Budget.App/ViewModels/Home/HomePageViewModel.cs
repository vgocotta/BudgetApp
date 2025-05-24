using Budget.App.Models;
using Budget.Infrastructure.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;

namespace Budget.App.ViewModels.Home;

public partial class HomePageViewModel : ObservableObject
{

    [ObservableProperty]
    private DateTime? _selectedDate;

    [ObservableProperty]
    private ICollection<BudgetValue> budgets = [];

    private readonly AppDbContext _context;

    public HomePageViewModel(AppDbContext context)
    {
        SelectedDate = DateTime.Now;
        _context = context;
    }

    public decimal? Total => Budgets?.Sum(x => x.Valor);

    private async Task SetBudgetList()
    {
        if (SelectedDate == null)
        {
            Budgets = [];
            OnPropertyChanged(nameof(Total));
            return;
        }

        int year = SelectedDate.Value.Year;
        int month = SelectedDate.Value.Month;
        var days = DateTime.DaysInMonth(year, month);

        DateTime begin = new(year, month, 1);
        DateTime end = new(year, month, days);

        Budgets = await _context
                  .Expenses
                  .Where
                  (
                  x => !x.IsPaid
                  && x.Date >= begin
                  && x.Date <= end
                  )
                  .GroupBy
                  (
                  k => k.Category.Name
                  )
                  .Select
                  (
                  g => new BudgetValue
                  {
                      Categoria = g.Key,
                      Valor = g.Sum(s => s.Amount)
                  }
                  )
                  .ToListAsync();

        OnPropertyChanged(nameof(Total));
    }

    [RelayCommand]
    private async Task LoadedPage()
    {
        await SetBudgetList();
    }

    [RelayCommand]
    private async Task OnSelectedDate()
    {
        await SetBudgetList();
    }
}
