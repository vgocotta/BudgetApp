using Budget.Core.Entities;
using Budget.Core.Interfaces;

namespace Budget.Core.Services;

public class CategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
        => await _repository.GetAllAsync();

    public async Task AddAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Category name is required.");

        var category = new Category { Name = name.Trim() };
        await _repository.AddAsync(category);
    }
}
