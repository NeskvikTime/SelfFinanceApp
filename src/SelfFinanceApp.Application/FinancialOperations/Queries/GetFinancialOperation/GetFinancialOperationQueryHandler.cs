using ErrorOr;
using MediatR;
using SelfFinanceApp.Domain.Contracts.Services;
using SelfFinanceApp.Domain.Aggregates;

namespace SelfFinanceApp.Application.FinancialOperations.Queries.GetFinancialOperation
{
    public class GetFinancialOperationQueryHandler : IRequestHandler<GetFinancialOperationQuery, ErrorOr<FinancialOperation>>
    {
        private readonly IFinancialOperationsService _financialOperationsService;

        public GetFinancialOperationQueryHandler(IFinancialOperationsService financialOperationsService)
        {
            _financialOperationsService = financialOperationsService;
        }

        public async Task<ErrorOr<FinancialOperation>> Handle(GetFinancialOperationQuery request, CancellationToken cancellationToken)
        {
            return await _financialOperationsService.GetByIdAsync(request.Id, cancellationToken) is not FinancialOperation operation
                ? Error.NotFound(description: $"Financial type not found Id: {request.Id}")
                : operation;
        }
    }
}
