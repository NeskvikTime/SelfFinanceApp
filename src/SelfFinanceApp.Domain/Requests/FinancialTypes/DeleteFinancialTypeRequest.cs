using SelfFinanceApp.Domain.Enums;

namespace SelfFinanceApp.Domain.Requests.FinancialTypes
{
    public record DeleteFinancialTypeRequest(string Name, TransactionDirection DirectionType);
}
