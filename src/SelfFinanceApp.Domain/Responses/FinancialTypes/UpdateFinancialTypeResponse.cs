using SelfFinanceApp.Domain.Enums;

namespace SelfFinanceApp.Domain.Responses.FinancialTypes
{
    public record UpdateFinancialTypeResponse(Guid Id , string Name, TransactionDirection TransactionType);
}
