using FluentValidation;
using SelfFinanceApp.Domain.Contracts.Services;

namespace SelfFinanceApp.Application.FinancialType.Commands.Patch
{
    public class PatchFinancialTypeCommandValidator : AbstractValidator<PatchFinancialTypeCommand>
    {
        private readonly IFinancialTypesService _financialTypesService;

        public PatchFinancialTypeCommandValidator(IFinancialTypesService financialTypesService)
        {
            _financialTypesService = financialTypesService;

            RuleFor(command => command.Id)
                .NotEmpty()
                .MustAsync(_financialTypesService.ExistsByIdAsync)
                .WithMessage("Financial type does not exist");

            RuleFor(command => command.PatchPayload)
                .NotNull();

            When(command => command.PatchPayload is not null, () =>
            {
                RuleFor(command => command.PatchPayload.Operations)
                    .NotEmpty()
                    .WithMessage("Patch payload must contain at least one operation");

                RuleFor(command => command.PatchPayload.Operations.Count)
                    .InclusiveBetween(1, 2)
                    .WithMessage("Patch payload must can contain only one or two operations!");

                RuleFor(command => command.PatchPayload.Operations)
                    .Must(operations => operations.TrueForAll(operation => operation.OperationType == Microsoft.AspNetCore.JsonPatch.Operations.OperationType.Replace))
                    .WithMessage("Patch payload must contain only replace operations!");

                RuleFor(command => command.PatchPayload.Operations)
                    .Must(operations => operations.TrueForAll(operation => operation.from is null))
                    .WithMessage("Patch payload must contain only replace operations without from!");

                RuleFor(command => command.PatchPayload.Operations)
                    .Must(operations => operations.TrueForAll(operation => operation.path.ToLower() == "name" || operation.path.ToLower() == "directiontype"))
                    .WithMessage("Patch payload must contain only replace operations for Name or DirectionType!");

                RuleFor(command => command.PatchPayload.Operations)
                    .Must(operations => operations.TrueForAll(operation => operation.value is not null))
                    .WithMessage("Patch payload must contain only replace operations with value!");
            });
        }
    }
}
