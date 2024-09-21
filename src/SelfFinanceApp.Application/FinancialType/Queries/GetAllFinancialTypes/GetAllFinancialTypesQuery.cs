using ErrorOr;
using MediatR;
using DomainEntities = SelfFinanceApp.Domain.Entities;

namespace SelfFinanceApp.Application.FinancialType.Queries.GetAllFinancialTypes
{
    public record GetAllFinancialTypesQuery() : 
        IRequest<ErrorOr<List<DomainEntities.FinancialType>>>;
}
