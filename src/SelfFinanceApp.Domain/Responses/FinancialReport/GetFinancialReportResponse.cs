using SelfFinanceApp.Domain.Pages;
using SelfFinanceApp.Domain.Responses.FinancialOperations;

namespace SelfFinanceApp.Domain.Responses.FinancialReport
{
    public record class GetFinancialReportResponse(
        DateOnly FromDate,
        DateOnly ToDate,
        decimal TotalIncome,
        decimal TotalExpenses,
        PagedResult<GetFinancialOperationResponse> FinancialOperations);
}
