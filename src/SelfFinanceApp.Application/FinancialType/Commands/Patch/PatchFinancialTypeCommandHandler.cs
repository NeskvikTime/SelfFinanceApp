using ErrorOr;
using MediatR;
using SelfFinanceApp.Domain.Contracts.Services;
using SelfFinanceApp.Domain.Requests.FinancialTypes;
using DomainEntities = SelfFinanceApp.Domain.Entities;

namespace SelfFinanceApp.Application.FinancialType.Commands.Patch;

public class PatchFinancialTypeCommandHandler : IRequestHandler<PatchFinancialTypeCommand, ErrorOr<DomainEntities.FinancialType>>
{
    private readonly IFinancialTypesService _financialTypesService;

    public PatchFinancialTypeCommandHandler(IFinancialTypesService financialTypesService)
    {
        _financialTypesService = financialTypesService;
    }

    public async Task<ErrorOr<DomainEntities.FinancialType>> Handle(
        PatchFinancialTypeCommand request,
        CancellationToken cancellationToken)
    {
        DomainEntities.FinancialType? financialType = await _financialTypesService.GetByIdAsync(request.Id, cancellationToken);

        if (financialType is null)
        {
            return Error.NotFound("Financial type not found");
        }

        PatchFinancialTypeRequest patchFinancialType = new PatchFinancialTypeRequest(financialType.Name, financialType.TransactionType);

        request.PatchPayload.ApplyTo(patchFinancialType);

        DomainEntities.FinancialType? updatedType = await _financialTypesService.UpdateAsync(request.Id,
                                                                                              patchFinancialType.Name,
                                                                                              patchFinancialType.DirectionType,
                                                                                              cancellationToken);

        if (updatedType is null)
        {
            return Error.NotFound("Financial type update error");
        }

        return updatedType;
    }
}
