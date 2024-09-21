using FluentValidation;
using SelfFinanceApp.Domain.Contracts.Services;

namespace SelfFinanceApp.Application.FinancialOperations.Commands.Update;

public class UpdateFinancialOperationCommandValidator : AbstractValidator<UpdateFinancialOperationCommand>
{
    private readonly IFinancialTypesService _financialTypesService;
    private readonly IFinancialOperationsService _financialOperationsService;

    public UpdateFinancialOperationCommandValidator(IFinancialTypesService financialTypesService, IFinancialOperationsService financialOperationsService)
    {
        _financialTypesService = financialTypesService;
        _financialOperationsService = financialOperationsService;

        RuleFor(command => command.Id)
            .NotEmpty()
            .MustAsync(_financialOperationsService.ExistsByIdAsync)
            .WithMessage($"Financial operation does not exist");

        When(command => command.FinanceTypeId.HasValue, () =>
        {
            RuleFor(command => command.FinanceTypeId)
                .NotEmpty()
                .MustAsync(async (financeTypeId, cancellationToken) =>
                    await _financialTypesService.ExistsByIdAsync(financeTypeId!.Value, CancellationToken.None))
                .WithMessage($"Financial type does not exist");
        });

        RuleFor(command => command.Amount)
            .NotEmpty()
            .WithMessage($"'{nameof(UpdateFinancialOperationCommand.Amount)}' is required.")
            .GreaterThan(0)
            .WithMessage($"'{nameof(UpdateFinancialOperationCommand.Amount)}' must be greater than 0.");

        RuleFor(command => command.Currency)
            .NotEmpty()
            .WithMessage($"'{nameof(UpdateFinancialOperationCommand.Currency)}' is required.")
            .MaximumLength(3)
            .WithMessage($"'{nameof(UpdateFinancialOperationCommand.Currency)}' must not exceed 3 characters.");
    }
}
