using ErrorOr;
using MediatR;
using SelfFinanceApp.Application.Extensions;
using SelfFinanceApp.Domain.Aggregates;
using SelfFinanceApp.Domain.Contracts.Services;
using SelfFinanceApp.Domain.Enums;
using SelfFinanceApp.Domain.Pages;
using SelfFinanceApp.Domain.Responses.FinancialOperations;

namespace SelfFinanceApp.Application.FinancialOperations.Queries.GetManyFinancialFinancialOperations
{
    public class GetManyFinancialOperationsQueryHandler : IRequestHandler<GetManyFinancialOperationsQuery, ErrorOr<PagedResult<GetFinancialOperationResponse>>>
    {
        private readonly IFinancialOperationsService _financialOperationsService;

        public GetManyFinancialOperationsQueryHandler(
            IFinancialOperationsService financialOperationsService)
        {
            _financialOperationsService = financialOperationsService;
        }

        public async Task<ErrorOr<PagedResult<GetFinancialOperationResponse>>> Handle(GetManyFinancialOperationsQuery request, CancellationToken cancellationToken)
        {
            DateTime startDate = request.FromDate.ToDateTime(TimeOnly.MinValue);
            DateTime endDate = request.ToDate.ToDateTime(TimeOnly.MinValue);

            SortOrder sortOrder = request.GetSortOrder();
            TransactionDirection? transactionDirection = request.GetTransactionDirection();

            int totalCount = await _financialOperationsService.GetCountAsync(
                transactionDirection,
                startDate,
                endDate,
                null, cancellationToken);

            List<FinancialOperation> operations = await _financialOperationsService.GetManyAsync(
                transactionDirection,
                startDate,
                endDate,
                request.Page,
                request.PageSize,
                sortOrder,
                request.SortField,
                cancellationToken, null);

            PagedResult<GetFinancialOperationResponse> result = new PagedResult<GetFinancialOperationResponse>()
            {
                Items = operations.Select(operation => new GetFinancialOperationResponse(
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

            return result;
        }
    }
}
