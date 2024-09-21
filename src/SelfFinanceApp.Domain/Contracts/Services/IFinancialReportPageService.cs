using SelfFinanceApp.Domain.Responses.FinancialReport;

namespace SelfFinanceApp.Domain.Contracts.Services
{
    public interface IFinancialReportPageService
    {
        Task<GetFinancialReportResponse> GetReportAsync(
            DateOnly selectedStartDate,
            DateOnly selectedEndDate,
            string currency,
            int page, CancellationToken token);
    }
}
