using ErrorOr;
using MediatR;
using SelfFinanceApp.Domain.Contracts.Services;

namespace SelfFinanceApp.Application.FinancialOperations.Commands.Delete
{
    public class DeleteFinancialOperationCommandHandler : IRequestHandler<DeleteFinancialOperationCommand, ErrorOr<Deleted>>
    {
        private readonly IFinancialOperationsService _financialOperationsService;

        public DeleteFinancialOperationCommandHandler(IFinancialOperationsService financialOperationsService)
        {
            _financialOperationsService = financialOperationsService;
        }

        public async Task<ErrorOr<Deleted>> Handle(DeleteFinancialOperationCommand request, CancellationToken cancellationToken)
        {
            bool result = await _financialOperationsService.DeleteByIdAsync(request.Id, cancellationToken);

            if (!result)
            {
                return Error.NotFound($"Financial operation not found Id: {request.Id}");
            }

            return Result.Deleted;
        }
    }
}
