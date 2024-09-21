using ErrorOr;
using MediatR;
using SelfFinanceApp.Domain.Contracts.Services;
using DomainEntities = SelfFinanceApp.Domain.Entities;

namespace SelfFinanceApp.Application.FinancialType.Commands.Update;

public class UpdateFinancialTypeCommandHandler : IRequestHandler<UpdateFinancialTypeCommand, ErrorOr<DomainEntities.FinancialType>>
{
    private readonly IFinancialTypesService _financialTypesRepository;

    public UpdateFinancialTypeCommandHandler(IFinancialTypesService financialTypesService)
    {
        _financialTypesRepository = financialTypesService;
    }

    public async Task<ErrorOr<DomainEntities.FinancialType>> Handle(UpdateFinancialTypeCommand request, CancellationToken token)
    {
        DomainEntities.FinancialType? financialType = await _financialTypesRepository.UpdateAsync(request.Id, request.Name, request.DirectionType, token);

        if (financialType is null)
        {
            return Error.NotFound("Financial type not found");
        }

        return financialType;
    }
}
