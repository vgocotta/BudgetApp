using Budget.App.ViewModels.Expenses;

namespace Budget.App.Views.Expenses;

public partial class ExpenseDetailPage : ContentPage
{
	public ExpenseDetailPage(ExpenseDetailPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}