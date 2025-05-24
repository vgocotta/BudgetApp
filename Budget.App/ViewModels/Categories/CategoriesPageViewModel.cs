using Budget.Core.Entities;
using Budget.Infrastructure.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;

namespace Budget.App.ViewModels.Categories;

public partial class CategoriesPageViewModel : ObservableObject
{
    [ObservableProperty]
    private ICollection<Category> categories = [];

    [ObservableProperty]
    private Category? _category = null;

    [ObservableProperty]
    private string newCategoryName = null!;

    private readonly AppDbContext _context;

    public CategoriesPageViewModel(AppDbContext dbContext)
    {
        _context = dbContext;
    }


    [RelayCommand]
    private async Task LoadedPage()
    {
        await _context.Categories.LoadAsync();
        Categories = _context.Categories.Local.ToObservableCollection();
    }

    [RelayCommand]
    private void AddNew()
    {
        if (string.IsNullOrWhiteSpace(NewCategoryName))
        {
            return;
        }

        Category newCategory = new()
        {
            Name = NewCategoryName
        };

        Categories.Add(newCategory);
    }

    [RelayCommand]
    private async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

    [RelayCommand]
    private void Delete()
    {
        if (Category == null)
        {
            return;
        }
        Categories.Remove(Category);
    }
}
