using ErrorOr;
using MediatR;
using SelfFinanceApp.Domain.Contracts.Requests;

namespace SelfFinanceApp.Application.FinancialOperations.Commands.Delete
{
    public record DeleteFinancialOperationCommand(Guid Id) : IRequest<ErrorOr<Deleted>>;
}
