using ErrorOr;
using SelfFinanceApp.Domain.Aggregates;
using SelfFinanceApp.Domain.Enums;

namespace SelfFinanceApp.Domain.Contracts.Services
{
    public interface IFinancialOperationsService
    {
        Task<ErrorOr<FinancialOperation>> AddFinancialOperationAsync(string name, decimal amount, string currency, Guid financialTypeId, CancellationToken cancellationToken);
        public Task<bool> DeleteByIdAsync(Guid id, CancellationToken token);
        Task<bool> ExistsByIdAsync(Guid id, CancellationToken token);
        Task<FinancialOperation> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<List<FinancialOperation>> GetManyAsync(
                    TransactionDirection? transactionType,
                    DateTime fromDate,
                    DateTime toDate,
                    int page,
                    int pageSize,
                    SortOrder sortOrder,
                    string? sortField,
                    CancellationToken token,
                    string currency = null);
        Task<int> GetCountAsync(TransactionDirection? transactionType, DateTime fromDate, DateTime toDate, string Currency, CancellationToken token);
        Task<bool> NameIsUniqueAsync(string name, CancellationToken token);
        Task<FinancialOperation?> UpdateAsync(Guid id, string name, decimal amount, string currency, CancellationToken token, Guid? financeTypeId = null);
        Task<decimal> GetDailyAmount(
            DateOnly startDate,
            DateOnly endDate,
            string currency,
            TransactionDirection transactionType,
            CancellationToken token);
    }
}
