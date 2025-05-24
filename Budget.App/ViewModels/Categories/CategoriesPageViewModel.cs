using Budget.Core.Entities;
using Budget.Core.Interfaces;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Budget.App.ViewModels.Categories;

public partial class CategoriesPageViewModel : ObservableObject
{
    [ObservableProperty]
    private ICollection<Category> categories = [];

    [ObservableProperty]
    private Category? _category = null;

    [ObservableProperty]
    private string newCategoryName = null!;

    private readonly ICategoryRepository _categoryRepository;
    public CategoriesPageViewModel(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }


    [RelayCommand]
    private async Task LoadedPage()
    {
        var categories = await _categoryRepository.GetAllAsync();
        Categories = categories.ToObservableCollection();
    }

    [RelayCommand]
    private async Task AddNew()
    {
        if (string.IsNullOrWhiteSpace(NewCategoryName))
        {
            return;
        }

        Category newCategory = new()
        {
            Name = NewCategoryName
        };

        await _categoryRepository.AddAsync(newCategory);

        Categories.Add(newCategory);
    }

    [RelayCommand]
    private async Task SaveChanges()
    {
        if (Category == null)
        {
            return;
        }
        await _categoryRepository.UpdateAsync(Category);
    }

    [RelayCommand]
    private async Task Delete()
    {
        if (Category == null)
        {
            return;
        }
        await _categoryRepository.DeleteAsync(Category.Id);
        Categories.Remove(Category);
    }
}
