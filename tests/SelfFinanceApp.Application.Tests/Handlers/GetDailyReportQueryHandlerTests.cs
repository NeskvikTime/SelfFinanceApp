using SelfFinanceApp.Application.DailyReport.Queries.GetDailyReport;
using SelfFinanceApp.Domain.Aggregates;
using SelfFinanceApp.Domain.Contracts.Services;
using SelfFinanceApp.Domain.Enums;
using SelfFinanceApp.Domain.Models;
using SelfFinanceApp.Domain.Pages;
using SelfFinanceApp.Domain.Responses.FinancialOperations;
using SelfFinanceApp.Tests.Shared.Builders;

namespace SelfFinanceApp.Application.Tests.Handlers;

public class GetDailyReportQueryHandlerTests
{
    private readonly Mock<IFinancialOperationsService> _financialOperationsServiceMock;
    private readonly GetDailyReportQueryHandler _handler;
    private readonly CancellationToken _cancellationToken;

    public GetDailyReportQueryHandlerTests()
    {
        _financialOperationsServiceMock = new Mock<IFinancialOperationsService>();
        _handler = new GetDailyReportQueryHandler(_financialOperationsServiceMock.Object);
        _cancellationToken = new CancellationToken();
    }

    [Fact]
    public async Task Handle_ShouldReturnFinancialReport_WhenValidQueryIsGiven()
    {
        // Arrange
        var query = new GetDailyReportQuery(DateOnly.FromDateTime(DateTime.Today), DateOnly.FromDateTime(DateTime.Today), "USD", 1, 10);

        var financialOperationResponses = new List<GetFinancialOperationResponse>
        {
            new GetFinancialOperationResponseBuilder()
                .WithName("Salary")
                .WithAmount(3000)
                .WithCurrency("USD")
                .WithFinancialTypeName("Primary Income")
                .WithDirectionType(TransactionDirection.Income)
                .WithDate(DateOnly.FromDateTime(DateTime.Today))
                .Build()
        };

        var pagedResult = new PagedResult<GetFinancialOperationResponse>
        {
            Items = financialOperationResponses,
            CurrentPage = query.Page,
            PageSize = query.PageSize,
            RowCount = financialOperationResponses.Count,
            PageCount = (int)Math.Ceiling((double)financialOperationResponses.Count / query.PageSize),
        };

        var financialOperation = new FinancialOperationBuilder()
            .WithId(financialOperationResponses[0].Id)
            .WithName(financialOperationResponses[0].Name)
            .WithMoney(new MonetaryValueBuilder()
                .WithAmount(financialOperationResponses[0].Amount)
                .WithCurrency(financialOperationResponses[0].Currency)
                .Build())
            .WithFinancialType(new FinancialTypeBuilder()
                .WithId(financialOperationResponses[0].FinancialTypeId)
                .WithName(financialOperationResponses[0].FinancialTypeName)
                .WithTransactionDirection(financialOperationResponses[0].DirectionType)
                .Build())
            .Build();

        financialOperation.DateCreated = DateTime.Today;

        var financialOperations = new List<FinancialOperation>
        {
            financialOperation
        };

        var totalIncome = financialOperationResponses.Where(o => o.DirectionType == TransactionDirection.Income).Sum(o => o.Amount);
        var totalExpense = financialOperationResponses.Where(o => o.DirectionType == TransactionDirection.Expense).Sum(o => o.Amount);

        _financialOperationsServiceMock.Setup(x => x.GetManyAsync(
            It.IsAny<TransactionDirection?>(),
            It.IsAny<DateTime>(),
            It.IsAny<DateTime>(),
            query.Page,
            query.PageSize,
            SortOrder.Descending,
            "Date",
            It.IsAny<CancellationToken>(),
            query.Currency))
        .ReturnsAsync(financialOperations);

        _financialOperationsServiceMock.Setup(x => x.GetCountAsync(
            null,
            It.IsAny<DateTime>(),
            It.IsAny<DateTime>(),
            query.Currency, _cancellationToken))
        .ReturnsAsync(pagedResult.RowCount);

        _financialOperationsServiceMock.Setup(x => x.GetDailyAmount(
            query.FromDate,
            query.ToDate,
            query.Currency,
            TransactionDirection.Income,
            _cancellationToken))
        .ReturnsAsync(totalIncome);

        _financialOperationsServiceMock.Setup(x => x.GetDailyAmount(
            query.FromDate,
            query.ToDate,
            query.Currency,
            TransactionDirection.Expense,
            _cancellationToken))
        .ReturnsAsync(totalExpense);

        // Act
        var result = await _handler.Handle(query, _cancellationToken);

        // Assert
        var expectedReport = new FinancialReport(
            pagedResult,
            totalIncome,
            totalExpense,
            query.Currency,
            pagedResult.RowCount
        );

        result.Value.Should().BeEquivalentTo(expectedReport);
    }
}
