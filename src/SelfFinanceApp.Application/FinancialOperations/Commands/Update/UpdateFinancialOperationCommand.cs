using ErrorOr;
using MediatR;
using SelfFinanceApp.Domain.Contracts.Requests;
using DomainAggregate = SelfFinanceApp.Domain.Aggregates;

namespace SelfFinanceApp.Application.FinancialOperations.Commands.Update
{
    public record UpdateFinancialOperationCommand(Guid Id, string Name, decimal Amount, string Currency, Guid? FinanceTypeId) : IValidatableRequest<ErrorOr<DomainAggregate.FinancialOperation>>;
}
