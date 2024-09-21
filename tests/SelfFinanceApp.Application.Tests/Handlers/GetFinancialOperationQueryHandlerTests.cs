using FluentAssertions;
using Moq;
using SelfFinanceApp.Application.FinancialOperations.Queries.GetFinancialOperation;
using SelfFinanceApp.Domain.Contracts.Services;
using SelfFinanceApp.Domain.Aggregates;
using SelfFinanceApp.Tests.Shared.Builders;

namespace SelfFinanceApp.Application.Tests.Handlers;

public class GetFinancialOperationQueryHandlerTests
{
    private readonly Mock<IFinancialOperationsService> _financialOperationsServiceMock;
    private readonly GetFinancialOperationQueryHandler _handler;

    public GetFinancialOperationQueryHandlerTests()
    {
        _financialOperationsServiceMock = new Mock<IFinancialOperationsService>();
        _handler = new GetFinancialOperationQueryHandler(_financialOperationsServiceMock.Object);
    }

    [Fact]
    public async Task Should_ReturnError_When_FinancialOperationNotFound()
    {
        // Arrange
        var query = new GetFinancialOperationQuery(Guid.NewGuid());
        var cancellationToken = new CancellationToken();

        _financialOperationsServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), cancellationToken))
            .ReturnsAsync((FinancialOperation)null);

        // Act
        var result = await _handler.Handle(query, cancellationToken);

        // Assert
        result.IsError.Should().BeTrue();
    }

    [Fact]
    public async Task Should_ReturnFinancialOperation_When_Found()
    {
        // Arrange
        var financialOperation = new FinancialOperationBuilder()
            .WithId(Guid.NewGuid())
            .WithName("Operation Name")
            .Build();

        var query = new GetFinancialOperationQuery(financialOperation.Id);
        var cancellationToken = new CancellationToken();

        _financialOperationsServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), cancellationToken))
            .ReturnsAsync(financialOperation);

        // Act
        var result = await _handler.Handle(query, cancellationToken);

        // Assert
        result.IsError.Should().Be(false);
        result.Value.Should().BeEquivalentTo(financialOperation);
    }
}
