using FluentValidation.TestHelper;
using SelfFinanceApp.Application.FinancialOperations.Commands.Create;
using SelfFinanceApp.Domain.Contracts.Services;
using SelfFinanceApp.Domain.Enums;
using SelfFinanceApp.Tests.Shared.Builders;

namespace SelfFinanceApp.Application.Tests.Validators;

public class CreateFinancialOperationCommandValidatorTests
{
    private readonly CreateFinancialOperationCommandValidator _validator;
    private readonly Mock<IFinancialOperationsService> _financialOperationsServiceMock;
    private readonly Mock<IFinancialTypesService> _financialTypesServiceMock;

    public CreateFinancialOperationCommandValidatorTests()
    {
        _financialOperationsServiceMock = new Mock<IFinancialOperationsService>();
        _financialTypesServiceMock = new Mock<IFinancialTypesService>();

        _validator = new CreateFinancialOperationCommandValidator(_financialOperationsServiceMock.Object, _financialTypesServiceMock.Object);
    }

    [Fact]
    public async Task Should_HaveError_When_FinancialTypeIdIsEmpty()
    {
        // Arrange
        var command = new CreateFinancialOperationCommand("Name", 100, "USD", Guid.Empty);

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.FinancialTypeId);
    }

    [Fact]
    public async Task Should_HaveError_When_NameIsEmpty()
    {
        // Arrange
        var command = new CreateFinancialOperationCommand("", 100, "USD", Guid.NewGuid());

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public async Task Should_HaveError_When_NameExceeds50Chars()
    {
        // Arrange
        var command = new CreateFinancialOperationCommand(new string('A', 51), 100, "USD", Guid.NewGuid());

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public async Task Should_HaveError_When_AmountIsZero()
    {
        // Arrange
        var command = new CreateFinancialOperationCommand("Name", 0, "USD", Guid.NewGuid());

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Amount);
    }

    [Fact]
    public async Task Should_HaveError_When_CurrencyIsEmpty()
    {
        // Arrange
        var command = new CreateFinancialOperationCommand("Name", 100, "", Guid.NewGuid());

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Currency);
    }

    [Fact]
    public async Task Should_HaveError_When_CurrencyExceeds3Chars()
    {
        // Arrange
        var command = new CreateFinancialOperationCommand("Name", 100, "USDD", Guid.NewGuid());

        // Act
        var result = await _validator.TestValidateAsync(command);

        // Act
        result.ShouldHaveValidationErrorFor(x => x.Currency);
    }

    [Fact]
    public async Task Should_NotHaveAnyValidationErrors_When_Valid()
    {
        // Arrange
        var validFinancialTypeId = Guid.NewGuid();

        var validFinancialType = new FinancialTypeBuilder()
                                    .WithId(validFinancialTypeId)
                                    .WithName("Income")
                                    .WithTransactionDirection(TransactionDirection.Income)
                                    .Build();

        _financialOperationsServiceMock
            .Setup(x => x.NameIsUniqueAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        _financialTypesServiceMock
            .Setup(x => x.GetByIdAsync(validFinancialTypeId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(validFinancialType);

        // Act
        var command = new CreateFinancialOperationCommand("ValidName", 123m, "USD", validFinancialTypeId);

        // Assert
        var result = await _validator.TestValidateAsync(command);
        result.ShouldNotHaveAnyValidationErrors();
    }
}