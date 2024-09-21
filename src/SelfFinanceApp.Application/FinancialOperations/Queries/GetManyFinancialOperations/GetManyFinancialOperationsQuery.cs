using ErrorOr;
using SelfFinanceApp.Domain.Contracts.Requests;
using SelfFinanceApp.Domain.Pages;
using SelfFinanceApp.Domain.Requests.FinancialOperations;
using SelfFinanceApp.Domain.Responses.FinancialOperations;

namespace SelfFinanceApp.Application.FinancialOperations.Queries.GetManyFinancialFinancialOperations
{
    public record GetManyFinancialOperationsQuery(
        TransactionType DirectionType,
        DateOnly FromDate,
        DateOnly ToDate,
        string? SortField,
        int Page,
        int PageSize,
        string? SortOrder) : IValidatableRequest<ErrorOr<PagedResult<GetFinancialOperationResponse>>>;
}
