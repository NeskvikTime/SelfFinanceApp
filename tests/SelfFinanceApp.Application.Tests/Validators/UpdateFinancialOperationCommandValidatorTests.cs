using FluentValidation.TestHelper;
using Moq;
using SelfFinanceApp.Application.FinancialOperations.Commands.Update;
using SelfFinanceApp.Domain.Contracts.Services;

namespace SelfFinanceApp.Application.Tests.Validators;

public class UpdateFinancialOperationCommandValidatorTests
{
    private readonly UpdateFinancialOperationCommandValidator _validator;
    private readonly Mock<IFinancialTypesService> _financialTypesServiceMock;
    private readonly Mock<IFinancialOperationsService> _financialOperationsServiceMock;

    public UpdateFinancialOperationCommandValidatorTests()
    {
        _financialTypesServiceMock = new Mock<IFinancialTypesService>();
        _financialOperationsServiceMock = new Mock<IFinancialOperationsService>();
        _validator = new UpdateFinancialOperationCommandValidator(_financialTypesServiceMock.Object, _financialOperationsServiceMock.Object);
    }

    [Fact]
    public async Task Should_HaveError_When_IdDoesNotExist()
    {
        // Arrange
        _financialOperationsServiceMock.Setup(x => x.ExistsByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(false);

        var command = new UpdateFinancialOperationCommand(
            Guid.NewGuid(),
            "TestName",
            10.0M,
            "USD",
            Guid.NewGuid()
        );

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Id);
    }

    [Fact]
    public async Task Should_HaveError_When_FinanceTypeIdIsInvalid()
    {
        // Arrange
        _financialTypesServiceMock.Setup(x => x.ExistsByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(false);

        var command = new UpdateFinancialOperationCommand(
            Guid.NewGuid(),
            "TestName",
            10.0M,
            "USD",
            Guid.NewGuid()
        );

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.FinanceTypeId);
    }

    [Fact]
    public async Task Should_HaveError_When_AmountIsZeroOrNegative()
    {
        // Arrange
        var command = new UpdateFinancialOperationCommand(
            Guid.NewGuid(),
            "TestName",
            0,
            "USD",
            Guid.NewGuid()
        );

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Amount);
    }

    [Fact]
    public async Task Should_HaveError_When_CurrencyExceedsMaxLength()
    {
        // Arrange
        var command = new UpdateFinancialOperationCommand(
            Guid.NewGuid(),
            "TestName",
            10.0M,
            "LONGCURRENCY",
            Guid.NewGuid()
        );

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Currency);
    }
}
