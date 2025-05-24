using Budget.Core.Entities;
using Budget.Core.Interfaces;
using Budget.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Budget.Infrastructure.Repositories;

public class ExpenseRepository : IExpenseRepository
{
    private readonly AppDbContext _context;

    public ExpenseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Expense>> GetAllAsync()
        => await _context.Expenses.Include(e => e.Category).ToListAsync();

    public async Task<IEnumerable<Expense>> GetCurrentMonthAsync()
    {
        var now = DateTime.Now;
        return await _context.Expenses
            .Where(e => e.Date.Month == now.Month && e.Date.Year == now.Year)
            .Include(e => e.Category)
            .ToListAsync();
    }

    public async Task<Expense?> GetByIdAsync(int id)
        => await _context.Expenses.FindAsync(id);

    public async Task AddAsync(Expense expense)
    {
        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Expense expense)
    {
        _context.Expenses.Update(expense);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var expense = await _context.Expenses.FindAsync(id);
        if (expense != null)
        {
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
        }
    }
}
