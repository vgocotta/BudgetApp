using Budget.App.ViewModels.Expenses;

namespace Budget.App.Views.Expenses;

public partial class ExpensesPage : ContentPage
{
	public ExpensesPage(ExpensesPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}