using FluentValidation;
using SelfFinanceApp.Domain.Contracts.Services;

namespace SelfFinanceApp.Application.FinancialType.Commands.Create;

public class CreateFinancialTypeCommandValidator : AbstractValidator<CreateFinancialTypeCommand>
{
    private readonly IFinancialTypesService _financialTypesService;

    public CreateFinancialTypeCommandValidator(IFinancialTypesService financialTypesService)
    {
        _financialTypesService = financialTypesService;

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage($"'{nameof(CreateFinancialTypeCommand.Name)}' is required.")
            .MaximumLength(50)
            .WithMessage($"'{nameof(CreateFinancialTypeCommand.Name)}' must not exceed 50 characters.");

        // Checking for unique name
        RuleFor(x => x.Name)
            .MustAsync(async (name, token) =>
            {
                bool isUnique = await _financialTypesService.NameIsUniqueAsync(name, token);

                return isUnique;
            })
            .WithMessage($"'{nameof(CreateFinancialTypeCommand.Name)}' must be unique.");

        RuleFor(x => x.DirectionType)
            .IsInEnum()
            .WithMessage($"'{nameof(CreateFinancialTypeCommand.DirectionType)}' must be a valid enum value.");

        RuleFor(x => x.DirectionType)
            .IsInEnum()
            .WithMessage($"'{nameof(CreateFinancialTypeCommand.DirectionType)}' must be a valid enum value.");
    }
}
