using SelfFinanceApp.Domain.Enums;

namespace SelfFinanceApp.Domain.Responses.FinancialTypes
{
    public record CreateFinancialTypeResponse(Guid Id, string Name, TransactionDirection TransactionType);
}
