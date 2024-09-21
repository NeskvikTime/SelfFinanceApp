using ErrorOr;
using MediatR;
using SelfFinanceApp.Domain.Contracts.Services;
using SelfFinanceApp.Domain.Aggregates;

namespace SelfFinanceApp.Application.FinancialOperations.Commands.Update;

public class UpdateFinancialOperationCommandHandler : IRequestHandler<UpdateFinancialOperationCommand, ErrorOr<FinancialOperation>>
{
    private readonly IFinancialOperationsService _financialTypesService;

    public UpdateFinancialOperationCommandHandler(IFinancialOperationsService financialOperationsService)
    {
        _financialTypesService = financialOperationsService;
    }

    public async Task<ErrorOr<FinancialOperation>> Handle(UpdateFinancialOperationCommand request, CancellationToken token)
    {
        FinancialOperation? financeOperation = await _financialTypesService.UpdateAsync(request.Id,
            request.Name,
            request.Amount,
            request.Currency,
            token,
            request.FinanceTypeId);

        if (financeOperation is null)
        {
            return Error.NotFound("Financial type not found");
        }

        return financeOperation;
    }
}
