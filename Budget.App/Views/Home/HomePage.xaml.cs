using Budget.App.ViewModels.Home;

namespace Budget.App.Views.Home;

public partial class HomePage : ContentPage
{
	public HomePage(HomePageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}