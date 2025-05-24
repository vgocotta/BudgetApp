using Budget.Core.Entities;
using Budget.Core.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.App.ViewModels.Expenses;

public partial class ExpensesPageViewModel : ObservableObject
{

    [ObservableProperty]
    private ICollection<Expense> expenses = [];

    [ObservableProperty]
    private Expense? selectedExpense = null!;

    private readonly IExpenseRepository _expenseRepository;

    public ExpensesPageViewModel(IExpenseRepository expenseRepository)
    {
        _expenseRepository = expenseRepository;
    }
}
