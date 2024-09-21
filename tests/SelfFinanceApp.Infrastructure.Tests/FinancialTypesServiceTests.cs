using ErrorOr;
using SelfFinanceApp.Domain.Enums;
using SelfFinanceApp.Infrastructure.Services;

namespace SelfFinanceApp.Infrastructure.Tests;

public class FinancialTypesServiceTests
{
    private readonly Mock<IFinancialTypesRepository> _repositoryMock;
    private readonly FinancialTypesService _service;
    private readonly CancellationToken _cancellationToken;

    public FinancialTypesServiceTests()
    {
        _repositoryMock = new Mock<IFinancialTypesRepository>();
        _service = new FinancialTypesService(_repositoryMock.Object);
        _cancellationToken = new CancellationToken();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnListOfFinancialTypes()
    {
        var financialType1 = new FinancialTypeBuilder()
            .WithName("Expense")
            .WithTransactionDirection(TransactionDirection.Expense)
            .Build();

        var financialType2 = new FinancialTypeBuilder()
            .WithName("Income")
            .WithTransactionDirection(TransactionDirection.Income)
            .Build();

        var cancellationToken = new CancellationToken();

        // Arrange
        var financialTypes = new List<FinancialType>
        {
            financialType1,
            financialType2
        };

        _repositoryMock
            .Setup(repo => repo.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(financialTypes);

        // Act
        var result = await _service.GetAllAsync(cancellationToken);

        // Assert
        result.Should().BeEquivalentTo(financialTypes);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnFinancialType_WhenExists()
    {
        // Arrange
        var financialTypeId = Guid.NewGuid();

        var financialType = new FinancialTypeBuilder()
                            .WithId(financialTypeId)
                            .WithName("Expense")
                            .Build();

        _repositoryMock.Setup(repo => repo.GetByIdAsync(financialTypeId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(financialType);

        // Act
        var result = await _service.GetByIdAsync(financialTypeId, _cancellationToken);

        // Assert
        result.Should().BeEquivalentTo(financialType);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNull_WhenDoesNotExist()
    {
        // Arrange
        var financialTypeId = Guid.NewGuid();

        FinancialType? expectedNullResult = null;

        _repositoryMock.Setup(repo => repo.GetByIdAsync(financialTypeId, It.IsAny<CancellationToken>())).ReturnsAsync(expectedNullResult);

        // Act
        var result = await _service.GetByIdAsync(financialTypeId, _cancellationToken);

        // Assert
        result.Should().BeEquivalentTo(expectedNullResult);
        result.Should().BeNull();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnFinancialType_WhenAddedSuccessfully()
    {
        // Arrange
        var financialType = new FinancialTypeBuilder()
                            .WithName("Expense")
                            .Build();

        _repositoryMock.Setup(repo => repo.AddAsync(financialType, It.IsAny<CancellationToken>()))
                       .ReturnsAsync(financialType);

        // Act
        var result = await _service.AddAsync(financialType, _cancellationToken);

        // Assert
        result.Should().BeOfType<ErrorOr<FinancialType>>();
        result.IsError.Should().BeFalse();
        result.Value.Should().BeEquivalentTo(financialType);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnError_WhenNotAdded()
    {
        // Arrange
        var financialType = new FinancialTypeBuilder()
                            .WithName("Expense")
                            .Build();

        FinancialType? addedNullFinancialType = null;

        _repositoryMock.Setup(repo => repo.AddAsync(financialType, It.IsAny<CancellationToken>()))
                       .ReturnsAsync(addedNullFinancialType);

        // Act
        var result = await _service.AddAsync(financialType, _cancellationToken);

        // Assert
        result.Should().BeOfType<ErrorOr<FinancialType>>();
        result.IsError.Should().BeTrue();
        result.Value.Should().BeNull();
        result.Value.Should().BeEquivalentTo(addedNullFinancialType);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateNameAndDirection()
    {
        // Arrange
        var id = Guid.NewGuid();

        var financialType = new FinancialTypeBuilder()
                            .WithId(id)
                            .WithName("Expense")
                            .WithTransactionDirection(TransactionDirection.Expense)
                            .Build();

        string newName = "NewTestName";
        TransactionDirection newTransactionDirection = TransactionDirection.Income;

        _repositoryMock.Setup(repo => repo.GetByIdAsync(id, It.IsAny<CancellationToken>()))
                       .ReturnsAsync(financialType);

        // Act
        FinancialType? result = await _service.UpdateAsync(id, newName, newTransactionDirection, _cancellationToken);

        // Assert
        result.Should().NotBeNull();
        result!.Name.Should().Be(newName);
        result.TransactionType.Should().Be(newTransactionDirection);
    }

    [Fact]
    public async Task DeleteByIdAsync_ShouldReturnTrue_WhenDeleted()
    {
        // Arrange
        var id = Guid.NewGuid();
        bool expectedResult = true;

        _repositoryMock.Setup(repo => repo.DeleteByIdAsync(id, It.IsAny<CancellationToken>()))
                       .ReturnsAsync(expectedResult);

        // Act
        var result = await _service.DeleteByIdAsync(id, _cancellationToken);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Fact]
    public async Task DeleteByIdAsync_ShouldReturnFalse_WhenNotDeleted()
    {
        // Arrange
        var id = Guid.NewGuid();
        bool expectedResult = false;

        _repositoryMock.Setup(repo => repo.DeleteByIdAsync(id, It.IsAny<CancellationToken>()))
                       .ReturnsAsync(expectedResult);

        // Act
        var result = await _service.DeleteByIdAsync(id, _cancellationToken);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Fact]
    public async Task ExistsByIdAsync_ShouldReturnTrue_WhenExists()
    {
        // Arrange
        var id = Guid.NewGuid();
        bool expectedResult = true;

        _repositoryMock.Setup(repo => repo.ExistsByIdAsync(id, It.IsAny<CancellationToken>()))
                       .ReturnsAsync(true);

        // Act
        var result = await _service.ExistsByIdAsync(id, _cancellationToken);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Fact]
    public async Task ExistsByIdAsync_ShouldReturnFalse_WhenNotExists()
    {
        // Arrange
        var id = Guid.NewGuid();
        bool expectedResult = false;

        _repositoryMock.Setup(repo => repo.ExistsByIdAsync(id, It.IsAny<CancellationToken>()))
                       .ReturnsAsync(expectedResult);

        // Act
        var result = await _service.ExistsByIdAsync(id, _cancellationToken);

        // Assert
        result.Should().Be(expectedResult);
    }
}
