using SelfFinanceApp.Domain.Enums;

namespace SelfFinanceApp.Domain.Responses.FinancialTypes
{
    public record GetFinancialTypeResponse(Guid Id, string Name, TransactionDirection TransactionType);
}
