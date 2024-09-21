using ErrorOr;
using MediatR;

namespace SelfFinanceApp.Application.FinancialType.Commands.Delete
{
    public record DeleteFinancialTypeCommand(Guid Id) 
        : IRequest<ErrorOr<Deleted>>;
}
