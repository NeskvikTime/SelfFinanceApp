using SelfFinanceApp.Domain.Pages;

namespace SelfFinanceApp.Domain.Responses.FinancialOperations
{
    public record class GetFinancialReportResponse(
        DateOnly FromDate,
        DateOnly ToDate,
        decimal TotalIncome,
        decimal TotalExpenses,
        PagedResult<GetFinancialOperationResponse> FinancialOperations);
}
