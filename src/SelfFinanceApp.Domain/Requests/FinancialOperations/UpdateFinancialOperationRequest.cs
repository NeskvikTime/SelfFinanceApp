namespace SelfFinanceApp.Domain.Requests.FinancialOperations
{
    public record UpdateFinancialOperationRequest(string Name, decimal Amount, string Currency, Guid? FinanceTypeId);
}
