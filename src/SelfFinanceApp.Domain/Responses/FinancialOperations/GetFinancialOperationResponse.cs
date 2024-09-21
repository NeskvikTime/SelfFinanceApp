using SelfFinanceApp.Domain.Enums;

namespace SelfFinanceApp.Domain.Responses.FinancialOperations
{
    public record GetFinancialOperationResponse(
        Guid Id,
        string Name,
        decimal Amount,
        string Currency,
        Guid FinancialTypeId,
        string FinancialTypeName,
        DateOnly Date,
        TransactionDirection DirectionType);
}
