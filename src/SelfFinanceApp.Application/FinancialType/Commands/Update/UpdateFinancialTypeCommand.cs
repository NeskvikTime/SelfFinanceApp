using ErrorOr;
using SelfFinanceApp.Domain.Contracts.Requests;
using SelfFinanceApp.Domain.Enums;
using DomainEntities = SelfFinanceApp.Domain.Entities;

namespace SelfFinanceApp.Application.FinancialType.Commands.Update
{
    public record UpdateFinancialTypeCommand(Guid Id, string Name, TransactionDirection DirectionType) 
        : IValidatableRequest<ErrorOr<DomainEntities.FinancialType>>;
}
