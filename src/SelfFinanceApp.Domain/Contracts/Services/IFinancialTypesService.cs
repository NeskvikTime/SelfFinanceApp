using ErrorOr;
using SelfFinanceApp.Domain.Entities;
using SelfFinanceApp.Domain.Enums;

namespace SelfFinanceApp.Domain.Contracts.Services
{
    public interface IFinancialTypesService
    {
        Task<List<FinancialType>> GetAllAsync(CancellationToken token);

        Task<FinancialType?> GetByIdAsync(Guid id, CancellationToken token);

        Task<ErrorOr<FinancialType>> AddAsync(FinancialType financialType, CancellationToken token);

        Task<FinancialType?> UpdateAsync(Guid id, string name, TransactionDirection direction, CancellationToken token);

        Task<bool> DeleteByIdAsync(Guid id, CancellationToken token);

        Task<bool> ExistsByIdAsync(Guid id, CancellationToken token);
        Task<bool> NameIsUniqueAsync(string name, CancellationToken token);
    }
}
