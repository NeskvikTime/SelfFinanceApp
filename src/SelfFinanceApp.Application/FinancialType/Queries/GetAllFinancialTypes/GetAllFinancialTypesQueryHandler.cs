using ErrorOr;
using MediatR;
using SelfFinanceApp.Domain.Contracts.Services;
using DomainEntities = SelfFinanceApp.Domain.Entities;

namespace SelfFinanceApp.Application.FinancialType.Queries.GetAllFinancialTypes
{
    public class GetAllFinancialTypesQueryHandler : IRequestHandler<GetAllFinancialTypesQuery, ErrorOr<List<DomainEntities.FinancialType>>>
    {
        private readonly IFinancialTypesService _financialTypesService;
        public GetAllFinancialTypesQueryHandler(IFinancialTypesService financialTypesService)
        {
            _financialTypesService = financialTypesService;
        }
        public async Task<ErrorOr<List<DomainEntities.FinancialType>>> Handle(GetAllFinancialTypesQuery request, CancellationToken token)
        {
            return await _financialTypesService.GetAllAsync(token);
        }
    }
}
