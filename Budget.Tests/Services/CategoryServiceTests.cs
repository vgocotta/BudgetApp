using Budget.Core.Interfaces;
using Budget.Core.Services;
using Moq;

namespace Budget.Tests.Services;

public class CategoryServiceTests
{
    [Fact]
    public async Task AddAsync_ShouldThrow_WhenNameIsEmpty()
    {
        var repo = new Mock<ICategoryRepository>();
        var service = new CategoryService(repo.Object);

        var exception = await Assert.ThrowsAsync<ArgumentException>(() =>
            service.AddAsync(""));

        Assert.Equal("Category name is required.", exception.Message);
    }

    [Fact]
    public async Task AddAsync_ShouldCallRepository_WhenNameIsValid()
    {
        var repo = new Mock<ICategoryRepository>();
        var service = new CategoryService(repo.Object);

        await service.AddAsync("Utilities");

        repo.Verify(r => r.AddAsync(It.IsAny<Budget.Core.Entities.Category>()), Times.Once);
    }
}
