using FluentValidation.TestHelper;
using Moq;
using SelfFinanceApp.Application.FinancialType.Commands.Update;
using SelfFinanceApp.Domain.Contracts.Services;
using SelfFinanceApp.Domain.Enums;

namespace SelfFinanceApp.Application.Tests.Validators;

public class UpdateFinancialTypeCommandValidatorTests
{
    private readonly UpdateFinancialTypeCommandValidator _validator;
    private readonly Mock<IFinancialTypesService> _financialTypesServiceMock;

    public UpdateFinancialTypeCommandValidatorTests()
    {
        _financialTypesServiceMock = new Mock<IFinancialTypesService>();
        _financialTypesServiceMock.Setup(x => x.ExistsByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

        _validator = new UpdateFinancialTypeCommandValidator(_financialTypesServiceMock.Object);
    }

    [Fact]
    public async Task Should_HaveError_When_NameIsEmpty()
    {
        // Arrange
        var command = new UpdateFinancialTypeCommand(Guid.NewGuid(), string.Empty, TransactionDirection.Income);

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public async Task Should_HaveError_When_DirectionTypeIsInvalid()
    {
        // Arrange
        var command = new UpdateFinancialTypeCommand(Guid.NewGuid(), "Some Name", (TransactionDirection)100);

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.DirectionType);

    }

    [Fact]
    public async Task Should_NotHaveError_When_Valid()
    {
        // Arrange
        var command = new UpdateFinancialTypeCommand(Guid.NewGuid(), "Some Name", TransactionDirection.Income);

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
