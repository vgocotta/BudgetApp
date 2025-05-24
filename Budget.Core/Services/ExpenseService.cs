using Budget.Core.Entities;
using Budget.Core.Interfaces;

namespace Budget.Core.Services;

public class ExpenseService
{
    private readonly IExpenseRepository _repository;

    public ExpenseService(IExpenseRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Expense>> GetAllAsync()
        => await _repository.GetAllAsync();

    public async Task<IEnumerable<Expense>> GetCurrentMonthAsync()
        => await _repository.GetCurrentMonthAsync();

    public async Task<Expense?> GetByIdAsync(int id)
        => await _repository.GetByIdAsync(id);

    public async Task AddAsync(string description, decimal amount, DateTime date, int categoryId)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description is required.");

        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        var expense = new Expense
        {
            Description = description.Trim(),
            Amount = amount,
            Date = date,
            IsPaid = false,
            CategoryId = categoryId
        };

        await _repository.AddAsync(expense);
    }

    public async Task MarkAsPaidAsync(int expenseId)
    {
        var expense = await _repository.GetByIdAsync(expenseId);
        if (expense == null)
            throw new ArgumentException($"Expense with ID {expenseId} not found.");

        expense.IsPaid = true;
        await _repository.UpdateAsync(expense);
    }

    public async Task DeleteAsync(int id)
        => await _repository.DeleteAsync(id);
}
