using SelfFinanceApp.Domain.Enums;
using SelfFinanceApp.Infrastructure.Services;

namespace SelfFinanceApp.Infrastructure.Tests;

public class FinancialOperationsServiceTests
{
    private readonly Mock<IFinancialOperationsRepository> _repositoryMock;
    private readonly FinancialOperationsService _service;
    private readonly CancellationToken _cancellationToken;

    public FinancialOperationsServiceTests()
    {
        _repositoryMock = new Mock<IFinancialOperationsRepository>();
        _service = new FinancialOperationsService(_repositoryMock.Object);
        _cancellationToken = new CancellationToken();
    }

    [Fact]
    public async Task GetCountAsync_ShouldReturnCorrectCount()
    {
        // Arrange

        TransactionDirection? transactionType = null;
        DateTime from = DateTime.MinValue;
        DateTime to = DateTime.MaxValue;
        string currency = "USD";

        int expectedResult = 5;

        _repositoryMock.Setup(repo => repo.GetCountAsync(transactionType, from, to, currency, It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedResult);

        // Act
        var result = await _service.GetCountAsync(transactionType, from, to, currency, _cancellationToken);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Fact]
    public async Task NameIsUniqueAsync_ShouldReturnTrue_WhenNameIsUnique()
    {
        // Arrange
        string uniqueName = "UniqueName";
        bool expectedResult = true;

        _repositoryMock.Setup(repo => repo.NameIsUniqueAsync(uniqueName, It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedResult);

        // Act
        var result = await _service.NameIsUniqueAsync(uniqueName, _cancellationToken);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Fact]
    public async Task GetDailyAmount_ShouldReturnAmount()
    {
        // Arrange
        var dateTime = DateTime.MinValue;
        var date = DateOnly.FromDateTime(dateTime);

        string currency = "USD";
        TransactionDirection transactionType = TransactionDirection.Income;

        decimal expectedResult = 100.99M;

        _repositoryMock.Setup(repo => repo.GetDailyAmount(dateTime, dateTime, currency, transactionType, It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedResult);

        // Act
        var result = await _service.GetDailyAmount(date, date, currency, transactionType, _cancellationToken);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnFinancialOperation()
    {
        // Arrange
        var financialOperationId = Guid.NewGuid();

        var monetaryValue = new MonetaryValueBuilder()
            .WithAmount(100)
            .WithCurrency("USD")
            .Build();

        var financialOperation = new FinancialOperationBuilder()
            .WithId(financialOperationId)
            .WithMonetaryValue(monetaryValue)
            .Build();

        _repositoryMock.Setup(repo => repo.GetByIdAsync(financialOperationId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(financialOperation);

        // Act
        var result = await _service.GetByIdAsync(financialOperationId, _cancellationToken);

        // Assert
        result.Should().BeEquivalentTo(financialOperation);
    }

    [Fact]
    public async Task DeleteByIdAsync_ShouldReturnTrue_WhenDeleteIsSuccessful()
    {
        // Arrange
        var id = Guid.NewGuid();
        var cancellationToken = new CancellationToken();

        bool expectedResult = true;

        _repositoryMock
            .Setup(repo => repo.DeleteByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedResult);

        // Act
        var result = await _service.DeleteByIdAsync(id, cancellationToken);

        // Assert
        result.Should().Be(expectedResult);
    }


    [Fact]
    public async Task DeleteByIdAsync_ShouldReturnFalse_WhenRepositoryReturnsFalse()
    {
        // Arrange
        var id = Guid.NewGuid();

        bool expectedResult = false;

        _repositoryMock.Setup(repo => repo.DeleteByIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedResult);

        // Act
        var result = await _service.DeleteByIdAsync(Guid.NewGuid(), _cancellationToken);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Fact]
    public async Task AddFinancialOperationAsync_ShouldReturnFinancialOperation_WhenAddedSuccessfully()
    {
        // Arrange
        var financialTypeId = Guid.NewGuid();
        string addedName = "TestAdded";
        decimal addedAmount = 150;
        string addedCurrency = "EUR";

        var cancellationToken = new CancellationToken();

        var financialType = new FinancialTypeBuilder()
                            .WithId(financialTypeId)
                            .WithName("Expense")
                            .Build();

        var monetaryValue = new MonetaryValueBuilder()
                            .WithAmount(100)
                            .WithCurrency("USD")
                            .Build();

        var financialOperation = new FinancialOperationBuilder()
                                .WithName("Test")
                                .WithMonetaryValue(monetaryValue)
                                .WithFinancialType(financialType)
                                .Build();

        _repositoryMock.Setup(repo => repo.AddAsync(addedName, addedAmount, addedCurrency, financialTypeId, It.IsAny<CancellationToken>()))
                       .ReturnsAsync(financialOperation);

        _repositoryMock.Setup(repo => repo.GetByIdAsync(financialOperation.Id, It.IsAny<CancellationToken>()))
                       .ReturnsAsync(financialOperation);

        // Act
        var result = await _service.AddFinancialOperationAsync(addedName, addedAmount, addedCurrency, financialTypeId, cancellationToken);

        // Assert
        result.Should().BeOfType<ErrorOr.ErrorOr<FinancialOperation>>();
        result.IsError.Should().BeFalse();
        result.Value.Should().BeEquivalentTo(financialOperation);
    }

    [Fact]
    public async Task AddFinancialOperationAsync_ShouldReturnError_WhenRepositoryReturnsNull()
    {
        // Arrange
        FinancialOperation? nullFinancialOperation = null;

        _repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<string>(), It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                       .ReturnsAsync(nullFinancialOperation);

        string addedName = "TestAdded";
        decimal addedAmount = 150;
        string addedCurrency = "EUR";
        var financialTypeId = Guid.NewGuid();

        // Act
        var result = await _service.AddFinancialOperationAsync(addedName, addedAmount, addedCurrency, financialTypeId, _cancellationToken);

        // Assert
        result.IsError.Should().BeTrue();
        result.Value.Should().BeEquivalentTo(nullFinancialOperation);
    }

    [Fact]
    public async Task ExistsByIdAsync_ShouldReturnTrue_WhenIdExists()
    {
        // Arrange
        var id = Guid.NewGuid();
        bool expectedResult = true;

        _repositoryMock.Setup(repo => repo.ExistsByIdAsync(id, It.IsAny<CancellationToken>())).ReturnsAsync(true);

        // Act
        var result = await _service.ExistsByIdAsync(id, _cancellationToken);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnUpdatedFinancialOperation_WhenUpdateIsSuccessful()
    {
        // Arrange
        var financialOperationId = Guid.NewGuid();

        var financialTypeId = Guid.NewGuid();
        string updatedName = "TestUpdated";
        decimal updatedAmount = 150;
        string updatedCurrency = "EUR";
        var updatedFinancialTypeId = Guid.NewGuid();

        var cancellationToken = new CancellationToken();

        var financialType = new FinancialTypeBuilder()
                            .WithId(financialTypeId)
                            .WithName("Expense")
                            .Build();

        var monetaryValue = new MonetaryValueBuilder()
                            .WithAmount(100)
                            .WithCurrency("USD")
                            .Build();

        var financialOperation = new FinancialOperationBuilder()
                                .WithId(financialOperationId)
                                .WithName("Test")
                                .WithMonetaryValue(monetaryValue)
                                .WithFinancialType(financialType)
                                .Build();

        _repositoryMock.Setup(repo => repo.GetByIdAsync(financialOperationId, It.IsAny<CancellationToken>()))
                       .ReturnsAsync(financialOperation);

        _repositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<FinancialOperation>(), It.IsAny<CancellationToken>()))
                       .Returns(Task.CompletedTask);

        // Act
        var result = await _service.UpdateAsync(
            financialOperationId,
            updatedName, updatedAmount,
            updatedCurrency,
            cancellationToken,
            updatedFinancialTypeId);

        // Assert
        result.Should().NotBeNull();
        result!.Name.Should().Be(updatedName);
        result.Money.Amount.Should().Be(updatedAmount);
        result.Money.Currency.Should().Be(updatedCurrency);
        result.FinanceTypeId.Should().Be(updatedFinancialTypeId);
    }

    [Fact]
    public async Task GetManyAsync_ShouldReturnListOfFinancialOperations()
    {
        // Arrange

        var financialOperation1 = new FinancialOperationBuilder().WithName("Test1").Build();
        var financialOperation2 = new FinancialOperationBuilder().WithName("Test2").Build();

        var financialOperations = new List<FinancialOperation>
        {
            financialOperation1,
            financialOperation2
        };

        TransactionDirection? transactionType = null;
        var fromDate = DateTime.MinValue;
        var toDate = DateTime.MaxValue;
        int page = 0;
        int pageSize = 10;
        SortOrder sortOrder = SortOrder.Ascending;
        string? sortField = null;
        var currency = "USD";


        _repositoryMock.Setup(repo => repo.GetManyAsync(transactionType, fromDate, toDate, page, pageSize, sortOrder, sortField, currency, It.IsAny<CancellationToken>()))
                       .ReturnsAsync(financialOperations);

        // Act
        var result = await _service.GetManyAsync(transactionType, fromDate, toDate, page, pageSize, sortOrder, sortField, _cancellationToken, currency);

        // Assert
        result.Should().BeEquivalentTo(financialOperations);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNull_WhenRepositoryReturnsNull()
    {
        // Arrange
        FinancialOperation? expectedResult = null;
        var id = Guid.NewGuid();
        string updatedName = "TestUpdated";
        decimal updatedAmount = 150;
        string updatedCurrency = "EUR";
        Guid? financialTypeId = null;


        _repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedResult);

        // Act
        var result = await _service.UpdateAsync(id, updatedName, updatedAmount, updatedCurrency, _cancellationToken, financialTypeId);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public async Task UpdateAsync_ShouldCallChangeFinanceTypeId_WhenFinanceTypeIdIsDifferent()
    {
        // Arrange
        var oldTypeId = Guid.NewGuid();
        var newTypeId = Guid.NewGuid();

        string updatedName = "TestUpdated";
        decimal updatedAmount = 150;
        string updatedCurrency = "EUR";

        var financialOperation = new FinancialOperationBuilder()
                                .WithId(Guid.NewGuid())
                                .WithFinancialType(new FinancialTypeBuilder().WithId(oldTypeId).Build())
                                .Build();

        _repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                       .ReturnsAsync(financialOperation);

        // Act
        var result = await _service.UpdateAsync(financialOperation.Id, updatedName, updatedAmount, updatedCurrency, _cancellationToken, newTypeId);

        // Assert
        result.Should().NotBeNull();
        result!.FinanceTypeId.Should().Be(newTypeId);
    }

    [Fact]
    public async Task UpdateAsync_ShouldNotCallChangeFinanceTypeId_WhenFinanceTypeIdIsSame()
    {
        // Arrange
        var typeId = Guid.NewGuid();

        string updatedName = "TestUpdated";
        decimal updatedAmount = 150;
        string updatedCurrency = "EUR";

        var financialOperation = new FinancialOperationBuilder()
                                .WithId(Guid.NewGuid())
                                .WithFinancialType(new FinancialTypeBuilder().WithId(typeId).Build())
                                .Build();

        _repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                       .ReturnsAsync(financialOperation);

        // Act
        var result = await _service.UpdateAsync(financialOperation.Id, updatedName, updatedAmount, updatedCurrency, _cancellationToken, typeId);

        // Assert
        result.Should().NotBeNull();
        result!.FinanceTypeId.Should().Be(typeId);
    }
}