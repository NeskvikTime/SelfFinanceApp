using ErrorOr;
using Microsoft.AspNetCore.JsonPatch;
using SelfFinanceApp.Application.FinancialType.Commands.Patch;
using SelfFinanceApp.Domain.Contracts.Services;
using SelfFinanceApp.Domain.Enums;
using SelfFinanceApp.Domain.Requests.FinancialTypes;
using SelfFinanceApp.Tests.Shared.Builders;
using DomainEntities = SelfFinanceApp.Domain.Entities;

namespace SelfFinanceApp.Application.Tests.Handlers;

public class PatchFinancialTypeCommandHandlerTests
{
    private readonly Mock<IFinancialTypesService> _financialTypesServiceMock;
    private readonly PatchFinancialTypeCommandHandler _handler;
    private readonly FinancialTypeBuilder _financialTypeBuilder;

    public PatchFinancialTypeCommandHandlerTests()
    {
        _financialTypesServiceMock = new Mock<IFinancialTypesService>();
        _handler = new PatchFinancialTypeCommandHandler(_financialTypesServiceMock.Object);
        _financialTypeBuilder = new FinancialTypeBuilder();
    }

    [Fact]
    public async Task Handle_ValidCommand_ShouldReturnUpdatedFinancialType()
    {
        // Arrange
        var existingFinancialType = _financialTypeBuilder.Build();

        var patchPayload = new JsonPatchDocument<PatchFinancialTypeRequest>();
        patchPayload.Replace(x => x.Name, "UpdatedName");

        var command = new PatchFinancialTypeCommand(existingFinancialType.Id, patchPayload);

        _financialTypesServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                  .ReturnsAsync(existingFinancialType);

        _financialTypesServiceMock.Setup(x => x.UpdateAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<TransactionDirection>(), It.IsAny<CancellationToken>()))
                                  .ReturnsAsync(existingFinancialType);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Value.Should().BeEquivalentTo(existingFinancialType);
    }

    [Fact]
    public async Task Handle_NonExistingId_ShouldReturnError()
    {
        // Arrange
        var id = Guid.NewGuid();
        var patchPayload = new JsonPatchDocument<PatchFinancialTypeRequest>();
        var command = new PatchFinancialTypeCommand(id, patchPayload);

        _financialTypesServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                  .ReturnsAsync((DomainEntities.FinancialType)null);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Type.Should().Be(ErrorType.NotFound);
    }

    [Fact]
    public async Task Handle_UpdateFails_ShouldReturnError()
    {
        // Arrange
        var existingFinancialType = _financialTypeBuilder.Build();

        var patchPayload = new JsonPatchDocument<PatchFinancialTypeRequest>();
        var command = new PatchFinancialTypeCommand(existingFinancialType.Id, patchPayload);

        _financialTypesServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                                  .ReturnsAsync(existingFinancialType);

        _financialTypesServiceMock.Setup(x => x.UpdateAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<TransactionDirection>(), It.IsAny<CancellationToken>()))
                                  .ReturnsAsync((DomainEntities.FinancialType)null);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Type.Should().Be(ErrorType.NotFound);
    }
}
