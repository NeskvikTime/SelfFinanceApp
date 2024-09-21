using FluentValidation.TestHelper;
using SelfFinanceApp.Application.FinancialOperations.Queries.GetManyFinancialFinancialOperations;
using SelfFinanceApp.Domain.Requests.FinancialOperations;

namespace SelfFinanceApp.Application.Tests.Validators;

public class GetManyFinancialOperationsQueryValidatorTests
{
    private readonly GetManyFinancialOperationsQueryValidator _validator;

    public GetManyFinancialOperationsQueryValidatorTests()
    {
        _validator = new GetManyFinancialOperationsQueryValidator();
    }

    [Fact]
    public void Should_HaveError_When_PageSizeIsGreaterThan100()
    {
        // Arrange
        var query = new GetManyFinancialOperationsQuery(
            TransactionType.Income,
            DateOnly.MinValue.AddDays(1),
            DateOnly.MinValue.AddDays(1),
            "Amount",
            1,
            101,
            "-"
        );

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(q => q.PageSize);
    }

    [Fact]
    public void Should_HaveError_When_PageIsLessThan1()
    {
        // Arrange
        var query = new GetManyFinancialOperationsQuery(
            TransactionType.Income,
            DateOnly.MinValue.AddDays(1),
            DateOnly.MinValue.AddDays(1),
            "Amount",
            0,
            10,
            "-"
        );

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(q => q.Page);
    }

    [Fact]
    public void Should_HaveError_When_FromDateIsMinValue()
    {
        // Arrange
        var query = new GetManyFinancialOperationsQuery(
            TransactionType.Income,
            DateOnly.MinValue,
            DateOnly.MinValue.AddDays(1),
            "Amount",
            1,
            10,
            "-"
        );

        // Act
        _validator.TestValidate(query);

        // Assert
        _validator.TestValidate(query).ShouldHaveValidationErrorFor(x => x.FromDate);
    }

    [Fact]
    public void Should_HaveError_When_ToDateIsMinValue()
    {
        // Arrange
        var query = new GetManyFinancialOperationsQuery(
            TransactionType.Income,
            DateOnly.MinValue.AddDays(1),
            DateOnly.MinValue,
            "Amount",
            1,
            10,
            "-"
        );

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(q => q.ToDate);
    }

    [Fact]
    public void Should_HaveError_When_SortOrderIsInvalid()
    {
        // Arrange
        var query = new GetManyFinancialOperationsQuery(
            TransactionType.Income,
            DateOnly.MinValue.AddDays(1),
            DateOnly.MinValue.AddDays(1),
            "Amount",
            1,
            10,
            "InvalidSortOrder"
        );

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(q => q.SortOrder);
    }

    [Fact]
    public void Should_NotHaveAnyValidationErrors_When_Valid()
    {
        // Arrange
        var query = new GetManyFinancialOperationsQuery(
            TransactionType.Income,
            DateOnly.MinValue.AddDays(1),
            DateOnly.MinValue.AddDays(1),
            "Amount",
            1,
            10,
            "-"
        );

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}

