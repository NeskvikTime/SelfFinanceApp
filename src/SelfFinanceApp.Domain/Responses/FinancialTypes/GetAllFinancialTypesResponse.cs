using SelfFinanceApp.Domain.Enums;
using SelfFinanceApp.Domain.Aggregates;

namespace SelfFinanceApp.Domain.Responses.FinancialTypes
{
    public record GetAllFinancialTypesResponse(Guid Id, string Name, TransactionDirection DirectionType);
}
