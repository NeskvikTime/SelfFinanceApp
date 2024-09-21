using FluentValidation;

namespace SelfFinanceApp.Application.FinancialOperations.Queries.GetManyFinancialFinancialOperations
{
    public class GetManyFinancialOperationsQueryValidator : AbstractValidator<GetManyFinancialOperationsQuery>
    {
        public GetManyFinancialOperationsQueryValidator()
        {
            RuleFor(query => query.PageSize)
                .LessThanOrEqualTo(100)
                .WithMessage("Page size cannot be greater than 100!")
                .GreaterThanOrEqualTo(1)
                .WithMessage("Page size cannot be less than 1!");

            RuleFor(query => query.Page)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Page cannot be less than 1!");

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

            RuleFor(query => query.SortOrder)
                .Must(x => x == null || x == "-" || x == "+")
                .WithMessage("Sort order should be null, '-' or '+'!");
        }
    }
}
