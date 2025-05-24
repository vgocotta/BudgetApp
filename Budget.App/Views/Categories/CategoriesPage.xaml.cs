using Budget.App.ViewModels.Categories;

namespace Budget.App.Views.Categories;

public partial class CategoriesPage : ContentPage
{
	public CategoriesPage(CategoriesPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}