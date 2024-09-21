using FluentValidation;
using SelfFinanceApp.Domain.Contracts.Services;

namespace SelfFinanceApp.Application.FinancialType.Commands.Update;

public class UpdateFinancialTypeCommandValidator : AbstractValidator<UpdateFinancialTypeCommand>
{
    private readonly IFinancialTypesService _financialTypesService;

    public UpdateFinancialTypeCommandValidator(IFinancialTypesService financialTypesService)
    {
        _financialTypesService = financialTypesService;

        RuleFor(command => command.Id)
            .NotEmpty()
            .MustAsync(_financialTypesService.ExistsByIdAsync)
            .WithMessage("Financial type does not exist");

        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage($"'{nameof(UpdateFinancialTypeCommand.Name)}' is required.")
            .MaximumLength(50)
            .WithMessage($"'{nameof(UpdateFinancialTypeCommand.Name)}' must not exceed 50 characters.");

        RuleFor(x => x.DirectionType)
            .IsInEnum()
            .WithMessage($"'{nameof(UpdateFinancialTypeCommand.DirectionType)}' must be a valid enum value.");
    }
}
