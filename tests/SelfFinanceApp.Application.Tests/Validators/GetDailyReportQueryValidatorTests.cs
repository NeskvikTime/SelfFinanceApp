using FluentValidation.TestHelper;
using SelfFinanceApp.Application.DailyReport.Queries.GetDailyReport;

namespace SelfFinanceApp.Application.Tests.Validators;

public class GetDailyReportQueryValidatorTests
{
    private readonly GetDailyReportQueryValidator _validator;

    public GetDailyReportQueryValidatorTests()
    {
        _validator = new GetDailyReportQueryValidator();
    }

    [Fact]
    public void Should_HaveError_When_PageSizeIsGreaterThan100()
    {
        // Arrange
        var query = new GetDailyReportQuery(
            PageSize: 101,
            Page: 1,
            Currency: "USD",
            FromDate: DateOnly.FromDateTime(DateTime.Today),
            ToDate: DateOnly.FromDateTime(DateTime.Today).AddDays(1)
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
        var query = new GetDailyReportQuery(
            PageSize: 10,
            Page: 0,
            Currency: "USD",
            FromDate: DateOnly.FromDateTime(DateTime.Today),
            ToDate: DateOnly.FromDateTime(DateTime.Today).AddDays(1)
        );

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(q => q.Page);
    }

    [Fact]
    public void Should_HaveError_When_CurrencyIsInvalid()
    {
        // Arrange
        var query = new GetDailyReportQuery(
            PageSize: 10,
            Page: 1,
            Currency: "INVALID",
            FromDate: DateOnly.FromDateTime(DateTime.Today),
            ToDate: DateOnly.FromDateTime(DateTime.Today.AddDays(1))
        );

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(q => q.Currency);
    }

    [Fact]
    public async Task Should_HaveError_When_FromDateIsMinimum()
    {
        // Arrange
        var query = new GetDailyReportQuery(
            PageSize: 10,
            Page: 1,
            Currency: "USD",
            FromDate: DateOnly.MinValue,
            ToDate: DateOnly.FromDateTime(DateTime.Today)
        );

        // Act
        var result = await _validator.TestValidateAsync(query);

        // Assert
        result.ShouldHaveValidationErrorFor(q => q.FromDate);
    }

    [Fact]
    public async Task Should_HaveError_When_ToDateIsMinimum()
    {
        // Arrange
        var query = new GetDailyReportQuery(
            PageSize: 10,
            Page: 1,
            Currency: "USD",
            FromDate: DateOnly.FromDateTime(DateTime.Today),
            ToDate: DateOnly.MinValue
        );

        // Act
        var result = await _validator.TestValidateAsync(query);

        // Assert
        result.ShouldHaveValidationErrorFor(q => q.ToDate);
    }
}
