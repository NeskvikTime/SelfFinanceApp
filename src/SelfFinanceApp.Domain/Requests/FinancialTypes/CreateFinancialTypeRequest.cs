using SelfFinanceApp.Domain.Enums;

namespace SelfFinanceApp.Domain.Requests.FinancialTypes
{
    public record CreateFinancialTypeRequest(string Name, TransactionDirection DirectionType);
}
