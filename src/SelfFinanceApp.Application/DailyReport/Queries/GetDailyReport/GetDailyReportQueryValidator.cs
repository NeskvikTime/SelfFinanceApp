using FluentValidation;
using SelfFinanceApp.Domain.Requests.FinancialReports;
using SelfFinanceApp.Domain.ValueObjects;

namespace SelfFinanceApp.Application.DailyReport.Queries.GetDailyReport
{
    public class GetDailyReportQueryValidator : AbstractValidator<GetDailyReportQuery>
    {
        public GetDailyReportQueryValidator()
        {
            RuleFor(query => query.PageSize)
                .LessThanOrEqualTo(100)
                .WithMessage("Page size cannot be greater than 100!")
                .GreaterThanOrEqualTo(1)
                .WithMessage("Page size cannot be less than 1!");

            RuleFor(query => query.Page)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Page cannot be less than 1!");

            RuleFor(query => query.Currency)
                .NotEmpty()
                .WithMessage("Currency should not be empty!")
                .Must(currency => MonetaryValue.CurrencyIsValid(currency) == true)
                .WithMessage("Currency is not valid! Valid currencies are EUR and USD");

            RuleFor(query => query.FromDate)
                .NotEmpty()
                .WithMessage("From date should not be empty!")
                .NotEqual(DateOnly.MinValue)
                .WithMessage("From date should not have minimum value!");

            RuleFor(query => query.ToDate)
                .NotEmpty()
                .WithMessage("To date should not be empty!")
                .NotEqual(DateOnly.MinValue)
                .WithMessage("To date should not have minimum value!");
        }
    }
}
