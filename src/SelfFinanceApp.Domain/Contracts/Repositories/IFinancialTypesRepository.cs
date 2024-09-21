using SelfFinanceApp.Domain.Entities;

namespace SelfFinanceApp.Domain.Contracts.Repositories
{
    public interface IFinancialTypesRepository
    {
        Task<List<FinancialType>> GetAllAsync(CancellationToken token);

        Task<FinancialType?> GetByIdAsync(Guid id, CancellationToken token);

        Task<FinancialType> AddAsync(FinancialType financialType, CancellationToken token);

        Task UpdateAsync(FinancialType financialType, CancellationToken token);

        Task<bool> DeleteByIdAsync(Guid financialTypeId, CancellationToken token);

        Task<bool> ExistsByIdAsync(Guid id, CancellationToken token);

        Task<bool> NameIsUniqueAsync(string name, CancellationToken token);
    }
}
