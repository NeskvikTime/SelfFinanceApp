using ErrorOr;
using MediatR;
using SelfFinanceApp.Domain.Aggregates;

namespace SelfFinanceApp.Application.FinancialOperations.Queries.GetFinancialOperation
{
    public record GetFinancialOperationQuery(Guid Id) : IRequest<ErrorOr<FinancialOperation>>;
}
