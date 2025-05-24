using Budget.Core.Entities;
using Budget.Core.Interfaces;
using Budget.Core.Services;
using FluentAssertions;
using Moq;

namespace Budget.Tests.Services;

public class ExpenseServiceTests
{
    [Fact]
    public async Task AddAsync_ShouldThrow_WhenDescriptionIsEmpty()
    {
        var repo = new Mock<IExpenseRepository>();
        var service = new ExpenseService(repo.Object);

        var act = async () => await service.AddAsync("", 100, DateTime.Now, 1);

        await act.Should().ThrowAsync<ArgumentException>()
            .WithMessage("Description is required.");
    }

    [Fact]
    public async Task AddAsync_ShouldThrow_WhenAmountIsZeroOrNegative()
    {
        var repo = new Mock<IExpenseRepository>();
        var service = new ExpenseService(repo.Object);

        var act = async () => await service.AddAsync("Internet", 0, DateTime.Now, 1);

        await act.Should().ThrowAsync<ArgumentException>()
            .WithMessage("Amount must be greater than zero.");
    }

    [Fact]
    public async Task AddAsync_ShouldCallRepository_WhenInputIsValid()
    {
        var repo = new Mock<IExpenseRepository>();
        var service = new ExpenseService(repo.Object);

        await service.AddAsync("Internet", 120, DateTime.Today, 1);

        repo.Verify(r => r.AddAsync(It.Is<Expense>(e =>
            e.Description == "Internet" &&
            e.Amount == 120 &&
            e.Date == DateTime.Today &&
            e.CategoryId == 1 &&
            e.IsPaid == false
        )), Times.Once);
    }

    [Fact]
    public async Task MarkAsPaidAsync_ShouldThrow_WhenExpenseNotFound()
    {
        var repo = new Mock<IExpenseRepository>();
        repo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Expense?)null);
        var service = new ExpenseService(repo.Object);

        var act = async () => await service.MarkAsPaidAsync(999);

        await act.Should().ThrowAsync<ArgumentException>()
            .WithMessage("Expense with ID 999 not found.");
    }

    [Fact]
    public async Task MarkAsPaidAsync_ShouldSetIsPaidToTrue_WhenValid()
    {
        var expense = new Expense
        {
            Id = 1,
            Description = "Internet",
            Amount = 100,
            Date = DateTime.Today,
            CategoryId = 1,
            IsPaid = false
        };

        var repo = new Mock<IExpenseRepository>();
        repo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(expense);
        var service = new ExpenseService(repo.Object);

        await service.MarkAsPaidAsync(1);

        expense.IsPaid.Should().BeTrue();
        repo.Verify(r => r.UpdateAsync(expense), Times.Once);
    }
}
