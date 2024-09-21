using ErrorOr;
using SelfFinanceApp.Domain.Contracts.Repositories;
using SelfFinanceApp.Domain.Contracts.Services;
using SelfFinanceApp.Domain.Entities;
using SelfFinanceApp.Domain.Enums;

namespace SelfFinanceApp.Infrastructure.Services
{
    public class FinancialTypesService : IFinancialTypesService
    {
        private readonly IFinancialTypesRepository _repository;
        public FinancialTypesService(IFinancialTypesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FinancialType>> GetAllAsync(CancellationToken token)
        {
            return await _repository.GetAllAsync(token);
        }

        public async Task<FinancialType?> GetByIdAsync(Guid id, CancellationToken token)
        {
            return await _repository.GetByIdAsync(id, token);
        }

        public async Task<ErrorOr<FinancialType>> AddAsync(FinancialType financialType, CancellationToken token)
        {
            FinancialType addedFinancialType = await _repository.AddAsync(financialType, token);

            if (addedFinancialType is null)
            {
                return Error.Conflict("Error Adding finance type!");
            }

            return financialType;
        }

        public async Task<FinancialType?> UpdateAsync(Guid id, string name, TransactionDirection direction, CancellationToken token)
        {
            FinancialType? financialType = await _repository.GetByIdAsync(id, token);

            if (financialType is null)
            {
                return null;
            }

            if (financialType.Name != name)
            {
                financialType.ChangeName(name);
            }

            if (financialType.TransactionType != direction)
            {
                financialType.ChangeDirectionType(direction);
            }

            await _repository.UpdateAsync(financialType, token);
            return financialType;
        }

        public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken token)
        {
            bool result = await _repository.DeleteByIdAsync(id, token);

            if (!result)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> ExistsByIdAsync(Guid id, CancellationToken token)
        {
            return await _repository.ExistsByIdAsync(id, token);
        }

        public async Task<bool> NameIsUniqueAsync(string name, CancellationToken token)
        {
            bool isUnique = await _repository.NameIsUniqueAsync(name, token);
            return isUnique;
        }
    }
}
