using FluentValidation;
using SelfFinanceApp.Domain.Contracts.Services;
using DomainEntities = SelfFinanceApp.Domain.Entities;

namespace SelfFinanceApp.Application.FinancialOperations.Commands.Create;

public class CreateFinancialOperationCommandValidator : AbstractValidator<CreateFinancialOperationCommand>
{
    private readonly IFinancialOperationsService _financialOperationsService;
    private readonly IFinancialTypesService _financialTypesService;

    public CreateFinancialOperationCommandValidator(
        IFinancialOperationsService financialOperationsService,
        IFinancialTypesService financialTypesService)
    {
        _financialOperationsService = financialOperationsService;
        _financialTypesService = financialTypesService;

        RuleFor(x => x.FinancialTypeId)
            .NotEmpty()
            .WithMessage($"'{nameof(CreateFinancialOperationCommand.FinancialTypeId)}' is required.")
            .MustAsync(async (id, token) =>
            {
                DomainEntities.FinancialType? result = await _financialTypesService.GetByIdAsync(id, token);

                return result is not null;
            })
            .WithMessage($"'{nameof(CreateFinancialOperationCommand.FinancialTypeId)}' must be a valid ID.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage($"'{nameof(CreateFinancialOperationCommand.Name)}' is required.")
            .MaximumLength(50)
            .WithMessage($"'{nameof(CreateFinancialOperationCommand.Name)}' must not exceed 50 characters.")
            .MustAsync(NameUniqueNameAsync)
            .WithMessage($"'{nameof(CreateFinancialOperationCommand.Name)}' must be unique.");

        RuleFor(x => x.Amount)
            .NotEmpty()
            .WithMessage($"'{nameof(CreateFinancialOperationCommand.Amount)}' is required.")
            .NotEqual(0)
            .WithMessage($"'{nameof(CreateFinancialOperationCommand.Amount)}' must be greater or less than 0.");

        RuleFor(x => x.Currency)
            .NotEmpty()
            .WithMessage($"'{nameof(CreateFinancialOperationCommand.Currency)}' is required.")
            .MaximumLength(3)
            .WithMessage($"'{nameof(CreateFinancialOperationCommand.Currency)}' must not exceed 3 characters.");
    }

    private async Task<bool> NameUniqueNameAsync(string name, CancellationToken token)
    {
        bool result = await _financialOperationsService.NameIsUniqueAsync(name, token);

        return result;
    }
}
