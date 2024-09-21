using ErrorOr;
using MediatR;
using SelfFinanceApp.Domain.Aggregates;
using SelfFinanceApp.Domain.Contracts.Services;
using SelfFinanceApp.Domain.Models;
using SelfFinanceApp.Domain.Pages;
using SelfFinanceApp.Domain.Responses.FinancialOperations;

namespace SelfFinanceApp.Application.DailyReport.Queries.GetDailyReport
{
    public class GetDailyReportQueryHandler : IRequestHandler<GetDailyReportQuery, ErrorOr<FinancialReport>>
    {
        private readonly IFinancialOperationsService _financialOperationsService;

        public GetDailyReportQueryHandler(
            IFinancialOperationsService financialOperationsService)
        {
            _financialOperationsService = financialOperationsService;
        }

        public async Task<ErrorOr<FinancialReport>> Handle(GetDailyReportQuery request, CancellationToken cancellationToken)
        {
            DateTime startDate = request.FromDate.ToDateTime(TimeOnly.MinValue);
            DateTime endDate = request.ToDate.ToDateTime(TimeOnly.MinValue);

            List<FinancialOperation> financialOperations = await _financialOperationsService.GetManyAsync(
                null,
                startDate,
                endDate,
                request.Page,
                request.PageSize,
                Domain.Enums.SortOrder.Descending,
                "Date",
                cancellationToken,
                request.Currency);

            int totalCount = await _financialOperationsService.GetCountAsync(
                null,
                startDate,
                endDate,
                request.Currency, cancellationToken);

            decimal totalIncome = await _financialOperationsService.GetDailyAmount(
                request.FromDate,
                request.ToDate,
                request.Currency,
                Domain.Enums.TransactionDirection.Income,
                cancellationToken);

            decimal totalExpense = await _financialOperationsService.GetDailyAmount(
                request.FromDate,
                request.ToDate,
                request.Currency,
                Domain.Enums.TransactionDirection.Expense,
                cancellationToken);

            PagedResult<GetFinancialOperationResponse> pagedFinancialOperations = new PagedResult<GetFinancialOperationResponse>()
            {
                Items = financialOperations.Select(operation => new GetFinancialOperationResponse(
                    operation.Id,
                    operation.Name,
                    operation.Money.Amount,
                    operation.Money.Currency,
                    operation.FinanceTypeId,
                    operation.FinanceType.Name,
                    DateOnly.FromDateTime(operation.DateCreated),
                    operation.FinanceType.TransactionType)).ToList(),
                CurrentPage = request.Page,
                PageSize = request.PageSize,
                RowCount = totalCount,
                PageCount = (int)Math.Ceiling((double)totalCount / request.PageSize)
            };

            FinancialReport dailyRepot = new FinancialReport(
                pagedFinancialOperations,
                totalIncome,
                totalExpense,
                request.Currency,
                totalCount);

            return dailyRepot;
        }
    }
}
