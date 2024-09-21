using ErrorOr;
using SelfFinanceApp.Domain.Contracts.Requests;
using SelfFinanceApp.Domain.Aggregates;

namespace SelfFinanceApp.Application.FinancialOperations.Commands.Create
{
    public record CreateFinancialOperationCommand(string Name, decimal Amount, string Currency, Guid FinancialTypeId) : IValidatableRequest<ErrorOr<FinancialOperation>>;
}
