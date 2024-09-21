using ErrorOr;
using MediatR;
using SelfFinanceApp.Domain.Contracts.Services;
using SelfFinanceApp.Domain.Aggregates;

namespace SelfFinanceApp.Application.FinancialOperations.Commands.Create;

public class CreateFinancialOperationCommandHandler : IRequestHandler<CreateFinancialOperationCommand, ErrorOr<FinancialOperation>>
{
    private readonly IFinancialOperationsService _financialOperationsService;

    public CreateFinancialOperationCommandHandler(IFinancialOperationsService financialOperationsService)
    {
        _financialOperationsService = financialOperationsService;
    }

    public async Task<ErrorOr<FinancialOperation>> Handle(CreateFinancialOperationCommand request, CancellationToken cancellationToken)
    {
        var result = await _financialOperationsService.AddFinancialOperationAsync(request.Name, request.Amount, request.Currency, request.FinancialTypeId, cancellationToken);

        if (result.IsError)
        {
            return Error.Conflict("Error Adding finance type!");
        }

        FinancialOperation operation = await _financialOperationsService.GetByIdAsync(result.Value.Id, cancellationToken);

        return operation;
    }
}
