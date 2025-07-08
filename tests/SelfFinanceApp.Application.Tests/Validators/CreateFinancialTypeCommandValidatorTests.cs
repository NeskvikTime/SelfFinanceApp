using FluentValidation.TestHelper;
using SelfFinanceApp.Application.FinancialType.Commands.Create;
using SelfFinanceApp.Domain.Contracts.Services;
using SelfFinanceApp.Domain.Enums;

namespace SelfFinanceApp.Application.Tests.Validators;


public class CreateFinancialTypeCommandValidatorTests
{
    private readonly CreateFinancialTypeCommandValidator _validator;
    private readonly Mock<IFinancialTypesService> _financialTypesServiceMock;

    public CreateFinancialTypeCommandValidatorTests()
    {
        _financialTypesServiceMock = new Mock<IFinancialTypesService>();
        _validator = new CreateFinancialTypeCommandValidator(_financialTypesServiceMock.Object);
    }

    [Fact]
    public async Task Should_HaveError_When_NameIsEmptyAsync()
    {
        // Arrange
        var command = new CreateFinancialTypeCommand(string.Empty, TransactionDirection.Income);

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public async Task Should_HaveError_When_NameIsNotUnique()
    {
        // Arrange
        var command = new CreateFinancialTypeCommand("Existing Name", TransactionDirection.Income);
        _financialTypesServiceMock.Setup(service => service.NameIsUniqueAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public async Task Should_HaveError_When_DirectionTypeIsInvalid()
    {
        // Arrange
        var command = new CreateFinancialTypeCommand("Some Name", (TransactionDirection)100);

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.TransactionType);
    }

    [Fact]
    public async Task Should_NotHaveError_When_Valid()
    {
        // Arrange
        var command = new CreateFinancialTypeCommand("Unique Name", TransactionDirection.Income);
        _financialTypesServiceMock.Setup(service => service.NameIsUniqueAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        // Act 
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}

