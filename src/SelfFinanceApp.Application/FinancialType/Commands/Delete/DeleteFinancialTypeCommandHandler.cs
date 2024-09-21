using ErrorOr;
using MediatR;
using SelfFinanceApp.Domain.Contracts.Services;

namespace SelfFinanceApp.Application.FinancialType.Commands.Delete
{
    public class DeleteFinancialTypeCommandHandler : IRequestHandler<DeleteFinancialTypeCommand, ErrorOr<Deleted>>
    {
        private readonly IFinancialTypesService _financialTypesService;

        public DeleteFinancialTypeCommandHandler(IFinancialTypesService financialTypesService)
        {
            _financialTypesService = financialTypesService;
        }
        public async Task<ErrorOr<Deleted>> Handle(DeleteFinancialTypeCommand request, CancellationToken cancellationToken)
        {
            bool result = await _financialTypesService.DeleteByIdAsync(request.Id, cancellationToken);

            if (!result)
            {
                return Error.NotFound($"Financial type not found Id: {request.Id}");
            }

            return Result.Deleted;
        }
    }
}
