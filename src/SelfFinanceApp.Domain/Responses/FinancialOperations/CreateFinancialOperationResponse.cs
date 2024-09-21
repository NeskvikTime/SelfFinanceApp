using SelfFinanceApp.Domain.Entities;
using SelfFinanceApp.Domain.Enums;

namespace SelfFinanceApp.Domain.Responses.FinancialOperations
{
    public record CreateFinancialOperationResponse(
        Guid Id, 
        string Name, 
        string Amount, 
        string Currency,
        Guid FinancialTypeId, 
        string FinancialTypeName, 
        DateTime DateCreated,
        TransactionDirection DirectionType);
}
