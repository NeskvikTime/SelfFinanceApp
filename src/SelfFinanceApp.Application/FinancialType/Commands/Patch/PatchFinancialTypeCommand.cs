using ErrorOr;
using Microsoft.AspNetCore.JsonPatch;
using SelfFinanceApp.Domain.Contracts.Requests;
using SelfFinanceApp.Domain.Requests.FinancialTypes;
using DomainEntities = SelfFinanceApp.Domain.Entities;

namespace SelfFinanceApp.Application.FinancialType.Commands.Patch;

public record PatchFinancialTypeCommand(Guid Id, JsonPatchDocument<PatchFinancialTypeRequest> PatchPayload)
: IValidatableRequest<ErrorOr<DomainEntities.FinancialType>>;