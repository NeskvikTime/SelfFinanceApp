using ErrorOr;
using MediatR;
using SelfFinanceApp.Domain.Contracts.Services;
using DomainEntities = SelfFinanceApp.Domain.Entities;

namespace SelfFinanceApp.Application.FinancialType.Commands.Create;

public class CreateFinancialTypeCommandHandler : IRequestHandler<CreateFinancialTypeCommand, ErrorOr<DomainEntities.FinancialType>>
{
    private readonly IFinancialTypesService _financialTypesService;

    public CreateFinancialTypeCommandHandler(IFinancialTypesService financialTypesService)
    {
        _financialTypesService = financialTypesService;
    }

    public async Task<ErrorOr<DomainEntities.FinancialType>> Handle(CreateFinancialTypeCommand request, CancellationToken token)
    {
        DomainEntities.FinancialType typeToAdd = new DomainEntities.FinancialType(request.Name, request.DirectionType);

        var financialType = await _financialTypesService.AddAsync(typeToAdd, token);

        if (financialType.IsError)
        {
            return Error.Conflict("Error Adding finance type!");
        }

        return financialType;
    }
}
