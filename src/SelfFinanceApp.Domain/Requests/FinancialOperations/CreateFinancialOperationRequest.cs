using ErrorOr;
using MediatR;
using SelfFinanceApp.Domain.Aggregates;

namespace SelfFinanceApp.Domain.Requests.FinancialOperations
{
    public record CreateFinancialOperationRequest(string Name, decimal Amount, string Currency, Guid FinancialTypeId);
}
