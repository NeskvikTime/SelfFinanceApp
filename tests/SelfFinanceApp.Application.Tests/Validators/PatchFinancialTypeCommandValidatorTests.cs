using FluentValidation.TestHelper;
using Microsoft.AspNetCore.JsonPatch;
using SelfFinanceApp.Application.FinancialType.Commands.Patch;
using SelfFinanceApp.Domain.Contracts.Services;
using SelfFinanceApp.Domain.Requests.FinancialTypes;

namespace SelfFinanceApp.Application.Tests.Validators;

public class PatchFinancialTypeCommandValidatorTests
{
    private readonly PatchFinancialTypeCommandValidator _validator;
    private readonly Mock<IFinancialTypesService> _financialTypesServiceMock;

    public PatchFinancialTypeCommandValidatorTests()
    {
        _financialTypesServiceMock = new Mock<IFinancialTypesService>();
        _validator = new PatchFinancialTypeCommandValidator(_financialTypesServiceMock.Object);
    }

    [Fact]
    public async Task Should_HaveError_When_IdDoesNotExist()
    {
        // Arrange
        _financialTypesServiceMock.Setup(x => x.ExistsByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(false);
        var command = new PatchFinancialTypeCommand(
            Guid.NewGuid(),
            new JsonPatchDocument<PatchFinancialTypeRequest>()
        );

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Id);
    }

    [Fact]
    public async Task Should_HaveError_When_PatchPayloadIsNull()
    {
        // Arrange
        var command = new PatchFinancialTypeCommand(
            Guid.NewGuid(),
            null!
        );

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.PatchPayload);
    }

    [Fact]
    public async Task Should_HaveError_When_PatchPayloadOperationsAreEmpty()
    {
        // Arrange
        var command = new PatchFinancialTypeCommand(
            Guid.NewGuid(),
            new JsonPatchDocument<PatchFinancialTypeRequest>()
        );

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.PatchPayload.Operations);
    }
}
