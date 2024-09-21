using MediatR;
using ErrorOr;
using DomainEntities = SelfFinanceApp.Domain.Entities;

namespace SelfFinanceApp.Application.FinancialType.Queries.GetFinanceType
{
    public record GetFinancialTypeQuery(Guid Id) : IRequest<ErrorOr<DomainEntities.FinancialType>>;
}
