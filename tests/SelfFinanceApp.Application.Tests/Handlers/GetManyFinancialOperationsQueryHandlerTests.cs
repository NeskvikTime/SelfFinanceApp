using SelfFinanceApp.Application.FinancialOperations.Queries.GetManyFinancialFinancialOperations;
using SelfFinanceApp.Domain.Aggregates;
using SelfFinanceApp.Domain.Contracts.Services;
using SelfFinanceApp.Domain.Enums;
using SelfFinanceApp.Domain.Pages;
using SelfFinanceApp.Domain.Requests.FinancialOperations;
using SelfFinanceApp.Domain.Responses.FinancialOperations;
using SelfFinanceApp.Tests.Shared.Builders;

namespace SelfFinanceApp.Application.Tests.Handlers;

public class GetManyFinancialOperationsQueryHandlerTests
{
    private readonly GetManyFinancialOperationsQueryHandler _handler;
    private readonly Mock<IFinancialOperationsService> _serviceMock;

    public GetManyFinancialOperationsQueryHandlerTests()
    {
        _serviceMock = new Mock<IFinancialOperationsService>();
        _handler = new GetManyFinancialOperationsQueryHandler(_serviceMock.Object);
    }

    [Fact]
    public async Task Should_ReturnData_When_ValidRequest()
    {
        // Arrange
        var financialOperations = new List<FinancialOperation>
    {
        new FinancialOperationBuilder()
            .WithFinancialType(new FinancialTypeBuilder()
            .WithTransactionDirection(TransactionDirection.Income)
            .Build())
            .Build(),
        new FinancialOperationBuilder()
            .WithFinancialType(new FinancialTypeBuilder()
            .WithTransactionDirection(TransactionDirection.Income)
            .Build())
            .Build(),
    };

        _serviceMock.Setup(x => x.GetManyAsync(
            It.IsAny<TransactionDirection?>(),
            It.IsAny<DateTime>(),
            It.IsAny<DateTime>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<SortOrder>(),
            It.IsAny<string>(),
            It.IsAny<CancellationToken>(),
            null
        )).ReturnsAsync(financialOperations);

        _serviceMock.Setup(x => x.GetCountAsync(
            It.IsAny<TransactionDirection?>(),
            It.IsAny<DateTime>(),
            It.IsAny<DateTime>(),
            null,
            It.IsAny<CancellationToken>()
        )).ReturnsAsync(financialOperations.Count);

        var query = new GetManyFinancialOperationsQuery(
            TransactionType.Income,
            DateOnly.FromDateTime(DateTime.Today),
            DateOnly.FromDateTime(DateTime.Today.AddDays(1)), "name", 1, 10, "+");

        var expectedResponse = new PagedResult<GetFinancialOperationResponse>
        {
            Items = financialOperations.Select(fo => new GetFinancialOperationResponse(
                fo.Id,
                fo.Name,
                fo.Money.Amount,
                fo.Money.Currency,
                fo.FinanceTypeId,
                fo.FinanceType.Name,
                DateOnly.FromDateTime(fo.DateCreated),
                fo.FinanceType.TransactionType
            )).ToList(),
            CurrentPage = query.Page,
            PageSize = query.PageSize,
            RowCount = financialOperations.Count,
            PageCount = (int)Math.Ceiling((double)financialOperations.Count / query.PageSize)
        };

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.IsError.Should().BeFalse();
        result.Value.Should().BeEquivalentTo(expectedResponse);
    }

    [Fact]
    public async Task Should_ReturnEmpty_When_NoRecords()
    {
        // Arrange
        _serviceMock.Setup(x => x.GetManyAsync(
            It.IsAny<TransactionDirection?>(),
            It.IsAny<DateTime>(),
            It.IsAny<DateTime>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<SortOrder>(),
            It.IsAny<string>(),
            It.IsAny<CancellationToken>(),
            null
        )).ReturnsAsync(new List<FinancialOperation>());

        var query = new GetManyFinancialOperationsQuery(
            TransactionType.Income,
            DateOnly.FromDateTime(DateTime.Today),
            DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
            "name", 1, 10, "+");

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        result.Value.Should().NotBeNull();
        result.Errors.Count.Should().Be(1);
    }

    [Fact]
    public async Task Should_ReturnError_When_ExceptionThrown()
    {
        // Arrange
        _serviceMock.Setup(x => x.GetManyAsync(
            It.IsAny<TransactionDirection?>(),
            It.IsAny<DateTime>(),
            It.IsAny<DateTime>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<SortOrder>(),
            It.IsAny<string>(),
            It.IsAny<CancellationToken>(),
            null
        )).ThrowsAsync(new Exception("Some exception"));

        var query = new GetManyFinancialOperationsQuery(
            TransactionType.Income,
            DateOnly.FromDateTime(DateTime.Today),
            DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
            "name", 1, 10, "+");

        // Act
        Func<Task> act = async () => { await _handler.Handle(query, CancellationToken.None); };

        await act.Should().ThrowAsync<Exception>().WithMessage("Some exception");
    }
}
