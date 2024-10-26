using SelfFinanceApp.Domain.Enums;

namespace SelfFinanceApp.Domain.Requests.FinancialTypes
{
    public record UpdateFinancialTypeRequest(string Name, TransactionDirection TransactionType);
}
