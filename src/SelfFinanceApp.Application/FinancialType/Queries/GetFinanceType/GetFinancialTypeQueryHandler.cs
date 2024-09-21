using ErrorOr;
using MediatR;
using SelfFinanceApp.Domain.Contracts.Repositories;
using DomainEntities = SelfFinanceApp.Domain.Entities;

namespace SelfFinanceApp.Application.FinancialType.Queries.GetFinanceType
{
    public class GetFinancialTypeQueryHandler : IRequestHandler<GetFinancialTypeQuery, ErrorOr<DomainEntities.FinancialType>>
    {
        private readonly IFinancialTypesRepository _financialTypeRepository;
        public GetFinancialTypeQueryHandler(IFinancialTypesRepository financialTypeRepository)
        {
            _financialTypeRepository = financialTypeRepository;
        }

        public async Task<ErrorOr<DomainEntities.FinancialType>> Handle(GetFinancialTypeQuery request, CancellationToken token)
        {
            return await _financialTypeRepository.GetByIdAsync(request.Id, token) is not DomainEntities.FinancialType financialType
                ? Error.NotFound(description: $"Financial type not found Id: {request.Id}")
                : financialType;
        }
    }
}