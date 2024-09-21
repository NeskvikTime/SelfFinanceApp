using ErrorOr;
using SelfFinanceApp.Domain.Aggregates;
using SelfFinanceApp.Domain.Contracts.Repositories;
using SelfFinanceApp.Domain.Contracts.Services;
using SelfFinanceApp.Domain.Enums;

namespace SelfFinanceApp.Infrastructure.Services;

public class FinancialOperationsService : IFinancialOperationsService
{
    private readonly IFinancialOperationsRepository _repository;

    public FinancialOperationsService(IFinancialOperationsRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<FinancialOperation>> AddFinancialOperationAsync(
        string name,
        decimal amount,
        string currency,
        Guid financialTypeId,
        CancellationToken cancellationToken)
    {
        var result = await _repository.AddAsync(name, amount, currency, financialTypeId, cancellationToken);

        if (result is null)
        {
            return Error.Conflict("Error Adding Financial Operation!");
        }

        FinancialOperation operation = await _repository.GetByIdAsync(result.Id, cancellationToken);

        return operation;
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

    public async Task<FinancialOperation> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<int> GetCountAsync(
        TransactionDirection? transactionType,
        DateTime fromDate,
        DateTime toDate,
        string currency,
        CancellationToken token)
    {
        return await _repository.GetCountAsync(transactionType, fromDate, toDate, currency, token);
    }

    public async Task<decimal> GetDailyAmount(
        DateOnly startDate,
        DateOnly endDate,
        string currency,
        TransactionDirection transactionType,
        CancellationToken token)
    {
        decimal amount = await _repository.GetDailyAmount(startDate.ToDateTime(TimeOnly.MinValue), endDate.ToDateTime(TimeOnly.MinValue), currency, transactionType, token);

        return amount;
    }


    public async Task<List<FinancialOperation>> GetManyAsync(
        TransactionDirection? transactionType,
        DateTime fromDate,
        DateTime toDate,
        int page,
        int pageSize,
        SortOrder sortOrder,
        string? sortField,
        CancellationToken token,
        string currency)
    {
        return await _repository.GetManyAsync(transactionType, fromDate, toDate, page, pageSize, sortOrder, sortField, currency, token);
    }

    public async Task<bool> NameIsUniqueAsync(string name, CancellationToken token)
    {
        return await _repository.NameIsUniqueAsync(name, token);
    }

    public async Task<FinancialOperation?> UpdateAsync(
        Guid id,
        string name,
        decimal amount,
        string currency,
        CancellationToken token,
        Guid? financeTypeId = null)
    {
        FinancialOperation? financialOperation = await _repository.GetByIdAsync(id, token);

        if (financialOperation is null)
        {
            return null;
        }

        if (financialOperation.Name != name)
        {
            financialOperation.ChangeName(name);
        }

        if (financialOperation.Money.Amount != amount ||
            string.Equals(financialOperation.Money.Currency, currency, StringComparison.OrdinalIgnoreCase))
        {
            financialOperation.Money = new Domain.ValueObjects.MonetaryValue(amount, currency);
        }

        if (financeTypeId.HasValue && financialOperation.FinanceTypeId != financeTypeId)
        {
            financialOperation.ChangeFinanceTypeId(financeTypeId.Value);
        }

        await _repository.UpdateAsync(financialOperation, token);

        financialOperation = await _repository.GetByIdAsync(id, token);

        return financialOperation;
    }
}
