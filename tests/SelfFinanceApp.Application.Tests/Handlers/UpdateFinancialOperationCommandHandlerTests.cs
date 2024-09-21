using FluentAssertions;
using Moq;
using SelfFinanceApp.Application.FinancialOperations.Commands.Update;
using SelfFinanceApp.Domain.Contracts.Services;
using SelfFinanceApp.Domain.Aggregates;
using SelfFinanceApp.Tests.Shared.Builders;

namespace SelfFinanceApp.Application.Tests.Handlers;


public class UpdateFinancialOperationCommandHandlerTests
{
    private readonly Mock<IFinancialOperationsService> _financialTypesServiceMock;
    private readonly UpdateFinancialOperationCommandHandler _handler;

    public UpdateFinancialOperationCommandHandlerTests()
    {
        _financialTypesServiceMock = new Mock<IFinancialOperationsService>();
        _handler = new UpdateFinancialOperationCommandHandler(_financialTypesServiceMock.Object);
    }

    [Fact]
    public async Task Should_ReturnError_When_FinancialOperationUpdateFails()
    {
        // Arrange
        var command = new UpdateFinancialOperationCommand(Guid.NewGuid(), "New Name", 200, "USD", Guid.NewGuid());
        var token = new CancellationToken();

        _financialTypesServiceMock.Setup(x => x.UpdateAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<string>(), token, It.IsAny<Guid>()))
            .ReturnsAsync((FinancialOperation)null);

        // Act
        var result = await _handler.Handle(command, token);

        // Assert
        result.IsError.Should().BeTrue();
    }

    [Fact]
    public async Task Should_ReturnFinancialOperation_When_UpdateSucceeds()
    {
        // Arrange
        var financialOperation = new FinancialOperationBuilder()
            .WithId(Guid.NewGuid())
            .WithName("Initial Name")
            .Build();
        var command = new UpdateFinancialOperationCommand(financialOperation.Id, "New Name", 200, "USD", Guid.NewGuid());
        var token = new CancellationToken();

        _financialTypesServiceMock.Setup(x => x.UpdateAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<decimal>(), It.IsAny<string>(), token, It.IsAny<Guid>()))
            .ReturnsAsync(financialOperation);

        // Act
        var result = await _handler.Handle(command, token);

        // Assert
        result.IsError.Should().BeFalse();
        result.Value.Should().BeEquivalentTo(financialOperation);
    }
}
