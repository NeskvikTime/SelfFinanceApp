using FluentAssertions;
using Moq;
using SelfFinanceApp.Application.FinancialOperations.Commands.Delete;
using SelfFinanceApp.Domain.Contracts.Services;

namespace SelfFinanceApp.Application.Tests.Handlers;

public class DeleteFinancialOperationCommandHandlerTests
{
    private readonly Mock<IFinancialOperationsService> _financialOperationsServiceMock;
    private readonly DeleteFinancialOperationCommandHandler _handler;

    public DeleteFinancialOperationCommandHandlerTests()
    {
        _financialOperationsServiceMock = new Mock<IFinancialOperationsService>();
        _handler = new DeleteFinancialOperationCommandHandler(_financialOperationsServiceMock.Object);
    }

    [Fact]
    public async Task Should_ReturnError_When_DeletingFinancialOperationFails()
    {
        // Arrange
        var command = new DeleteFinancialOperationCommand(Guid.NewGuid());
        var cancellationToken = new CancellationToken();

        _financialOperationsServiceMock.Setup(x => x.DeleteByIdAsync(It.IsAny<Guid>(), cancellationToken))
            .ReturnsAsync(false);

        // Act
        var result = await _handler.Handle(command, cancellationToken);

        // Assert
        result.IsError.Should().BeTrue();
    }

    [Fact]
    public async Task Should_ReturnDeleted_When_DeletingSucceeds()
    {
        // Arrange
        var command = new DeleteFinancialOperationCommand(Guid.NewGuid());
        var cancellationToken = new CancellationToken();

        _financialOperationsServiceMock.Setup(x => x.DeleteByIdAsync(It.IsAny<Guid>(), cancellationToken))
            .ReturnsAsync(true);

        // Act
        var result = await _handler.Handle(command, cancellationToken);

        // Assert
        result.IsError.Should().BeFalse();
    }
}
