using SelfFinanceApp.Domain.Aggregates;
using SelfFinanceApp.Domain.Enums;

namespace SelfFinanceApp.Domain.Contracts.Repositories
{
    public interface IFinancialOperationsRepository
    {
        Task<FinancialOperation> AddAsync(string name, decimal amount, string currency, Guid financialTypeId, CancellationToken cancellationToken);
        Task<bool> DeleteByIdAsync(Guid id, CancellationToken token);
        Task<bool> ExistsByIdAsync(Guid id, CancellationToken token);
        Task<FinancialOperation> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<int> GetCountAsync(TransactionDirection? transactionType, DateTime fromDate, DateTime toDate, string currency, CancellationToken cancellationToken);
        Task<List<FinancialOperation>> GetManyAsync(
            TransactionDirection? transactionType,
            DateTime fromDate,
            DateTime toDate,
            int page,
            int pageSize,
            SortOrder sortOrder,
            string? sortField,
            string currency,
            CancellationToken token);
        Task<bool> NameIsUniqueAsync(string name, CancellationToken token);
        Task UpdateAsync(FinancialOperation financeOperation, CancellationToken token);
        Task<decimal> GetDailyAmount(DateTime startDate, DateTime endDate, string currency, TransactionDirection transactionType, CancellationToken token);
    }
}
