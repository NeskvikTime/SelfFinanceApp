using Microsoft.EntityFrameworkCore;
using SelfFinanceApp.Domain.Contracts.Repositories;
using SelfFinanceApp.Domain.Entities;
using SelfFinanceApp.Persistance.DatabaseContext;

namespace SelfFinanceApp.Persistance.Repositories
{
    internal class FinancialTypesRepository : IFinancialTypesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FinancialTypesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FinancialType>> GetAllAsync(CancellationToken token)
        {
            return await _dbContext.FinancialTypes
                .OrderByDescending(financialType => financialType.DateCreated)
                .ToListAsync(token);
        }

        public async Task<FinancialType?> GetByIdAsync(Guid id, CancellationToken token)
        {
            return await _dbContext.FinancialTypes.FirstOrDefaultAsync(type => type.Id == id, token);
        }

        public async Task<FinancialType> AddAsync(FinancialType financialType, CancellationToken token)
        {
            var addedFinancialType = await _dbContext.FinancialTypes.AddAsync(financialType, token);
            await _dbContext.SaveChangesAsync(token);

            return addedFinancialType.Entity;
        }

        public async Task UpdateAsync(FinancialType financialType, CancellationToken token)
        {
            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<bool> DeleteByIdAsync(Guid financialTypeId, CancellationToken token)
        {
            var financialType = await _dbContext.FinancialTypes
                .Include(type => type.FinancialOperations)
                .FirstOrDefaultAsync(ft => ft.Id == financialTypeId, token);

            if (financialType == null)
            {
                return false;
            }

            if (financialType.FinancialOperations.Count > 0)
            {
                throw new Exception($"Financial type {financialType.Name} is already defined in at least one of the Financial Operations! Please delete them first");
            }

            _dbContext.FinancialTypes.Remove(financialType);
            await _dbContext.SaveChangesAsync(token);

            return true;
        }

        public async Task<bool> ExistsByIdAsync(Guid id, CancellationToken token)
        {
            return await _dbContext.FinancialTypes.AnyAsync(ft => ft.Id == id, token);
        }

        public async Task<bool> NameIsUniqueAsync(string name, CancellationToken token)
        {
            return !await _dbContext.FinancialTypes.AnyAsync(ft => ft.Name == name, token);
        }
    }
}
