using FluentAssertions;
using Moq;
using SelfFinanceApp.Application.FinancialType.Commands.Update;
using SelfFinanceApp.Domain.Contracts.Services;
using DomainEntities = SelfFinanceApp.Domain.Entities;
using SelfFinanceApp.Domain.Enums;
using SelfFinanceApp.Tests.Shared.Builders;

namespace SelfFinanceApp.Application.Tests.Handlers;

public class UpdateFinancialTypeCommandHandlerTests
{
    private readonly Mock<IFinancialTypesService> _financialTypesServiceMock;
    private readonly UpdateFinancialTypeCommandHandler _handler;
    private readonly FinancialTypeBuilder _financeTypeBuilder;

    public UpdateFinancialTypeCommandHandlerTests()
    {
        _financialTypesServiceMock = new Mock<IFinancialTypesService>();
        _handler = new UpdateFinancialTypeCommandHandler(_financialTypesServiceMock.Object);
        _financeTypeBuilder = new FinancialTypeBuilder();
    }

    [Fact]
    public async Task Handle_ValidCommand_ShouldReturnUpdatedFinancialType()
    {
        // Arrange
        var existingFinancialType = _financeTypeBuilder.Build();
        var updateCommand = new UpdateFinancialTypeCommand(existingFinancialType.Id, "UpdatedName", TransactionDirection.Expense);

        _financialTypesServiceMock.Setup(x => x.UpdateAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<TransactionDirection>(), It.IsAny<CancellationToken>()))
                                  .ReturnsAsync(existingFinancialType);

        // Act
        var result = await _handler.Handle(updateCommand, CancellationToken.None);

        // Assert
        result.Value.Should().BeEquivalentTo(existingFinancialType);
    }

    [Fact]
    public async Task Handle_InvalidId_ShouldReturnError()
    {
        // Arrange
        var id = Guid.NewGuid();
        var updateCommand = new UpdateFinancialTypeCommand(id, "InvalidName", TransactionDirection.Expense);

        _financialTypesServiceMock.Setup(x => x.UpdateAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<TransactionDirection>(), It.IsAny<CancellationToken>()))
                                  .ReturnsAsync((DomainEntities.FinancialType)null);

        // Act
        var result = await _handler.Handle(updateCommand, CancellationToken.None);

        // Assert
        result.IsError.Should().BeTrue();
    }
}
