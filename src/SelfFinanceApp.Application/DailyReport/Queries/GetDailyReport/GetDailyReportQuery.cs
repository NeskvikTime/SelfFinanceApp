using ErrorOr;
using MediatR;
using SelfFinanceApp.Domain.Contracts.Requests;
using SelfFinanceApp.Domain.Models;

namespace SelfFinanceApp.Application.DailyReport.Queries.GetDailyReport
{
    public record GetDailyReportQuery(
        DateOnly FromDate,
        DateOnly ToDate,
        string Currency,
        int Page,
        int PageSize) : IValidatableRequest<ErrorOr<FinancialReport>>;
}
