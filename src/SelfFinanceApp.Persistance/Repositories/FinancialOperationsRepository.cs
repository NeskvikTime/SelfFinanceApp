using Microsoft.EntityFrameworkCore;
using SelfFinanceApp.Domain.Aggregates;
using SelfFinanceApp.Domain.Contracts.Repositories;
using SelfFinanceApp.Domain.Enums;
using SelfFinanceApp.Domain.ValueObjects;
using SelfFinanceApp.Persistance.DatabaseContext;
using System.Linq.Expressions;

namespace SelfFinanceApp.Persistance.Repositories;

internal class FinancialOperationsRepository : IFinancialOperationsRepository
{
    private readonly ApplicationDbContext _dbContext;

    public FinancialOperationsRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private static Expression<Func<FinancialOperation, object>> GetSortProperty(string sortField)
    {
        switch (sortField!.ToLower())
        {
            case "date":
                return operation => operation.DateCreated;
            case "directiontype":
                return operation => operation.FinanceType.TransactionType;
            case "name":
                return operation => operation.Name;
            case "currency":
                return operation => operation.Money.Currency;
            case "amount":
                return operation => operation.Money.Amount;
            default:
                throw new ArgumentOutOfRangeException(nameof(sortField), sortField, null);
        }
    }

    public async Task<FinancialOperation> AddAsync(string name, decimal amount, string currency, Guid financialTypeId, CancellationToken cancellationToken)
    {
        MonetaryValue monetaryValue = new MonetaryValue(amount, currency);

        FinancialOperation financialOperationToAdd = new FinancialOperation(name, monetaryValue, financialTypeId);

        var financialOperationEntry = await _dbContext.FinancialOperations.AddAsync(financialOperationToAdd, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return financialOperationEntry.Entity;
    }

    public async Task<bool> NameIsUniqueAsync(string name, CancellationToken token)
    {
        bool nameIsUnique = await _dbContext.FinancialOperations.AnyAsync(operation => operation.Name == name, token);

        return !nameIsUnique;
    }

    public async Task<FinancialOperation> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        FinancialOperation? operation = await _dbContext.FinancialOperations
            .Include(operation => operation.FinanceType)
            .AsSplitQuery()
            .FirstOrDefaultAsync(operation => operation.Id == id, cancellationToken);

        return operation!;
    }

    public async Task<List<FinancialOperation>> GetManyAsync(
        TransactionDirection? transactionType,
        DateTime fromDate,
        DateTime toDate,
        int page,
        int pageSize,
        SortOrder sortOrder,
        string? sortField,
        string currency,
        CancellationToken token)
    {
        IQueryable<FinancialOperation> financialOperationsQuery = _dbContext.FinancialOperations
            .Include(operation => operation.FinanceType)
            .Where(operation => operation.DateCreated.Date >= fromDate.Date && operation.DateCreated.Date <= toDate.Date)
            .AsSplitQuery();

        if (!string.IsNullOrWhiteSpace(currency))
        {
            financialOperationsQuery = financialOperationsQuery.Where(operation => operation.Money.Currency == currency);
        }

        if (transactionType is not null)
        {
            financialOperationsQuery = financialOperationsQuery
                .Where(operation => operation.FinanceType.TransactionType == transactionType);
        }

        if (string.IsNullOrWhiteSpace(sortField))
        {
            financialOperationsQuery = financialOperationsQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            return await financialOperationsQuery.ToListAsync(token);
        }

        if (sortOrder == SortOrder.Descending)
        {
            financialOperationsQuery = financialOperationsQuery.OrderByDescending(GetSortProperty(sortField));
        }
        else if (sortOrder == SortOrder.Ascending)
        {
            financialOperationsQuery = financialOperationsQuery.OrderBy(GetSortProperty(sortField));
        }

        financialOperationsQuery = financialOperationsQuery
            .Skip((page - 1) * pageSize)
            .Take(pageSize);

        return await financialOperationsQuery.ToListAsync(token);
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken token)
    {
        var financialOperation = await _dbContext.FinancialOperations.FirstOrDefaultAsync(ft => ft.Id == id, token);
        if (financialOperation is null)
        {
            return false;
        }

        _dbContext.FinancialOperations.Remove(financialOperation);
        await _dbContext.SaveChangesAsync(token);

        return true;
    }

    public async Task<bool> ExistsByIdAsync(Guid id, CancellationToken token)
    {
        return await _dbContext.FinancialOperations.AnyAsync(ft => ft.Id == id, token);
    }

    public async Task UpdateAsync(FinancialOperation financeOperation, CancellationToken token)
    {
        _dbContext.FinancialOperations.Update(financeOperation);
        await _dbContext.SaveChangesAsync(token);
    }

    public async Task<int> GetCountAsync(
        TransactionDirection? transactionType,
        DateTime fromDate,
        DateTime toDate,
        string currency,
        CancellationToken cancellationToken)
    {
        IQueryable<FinancialOperation> financialOperationsQuery = _dbContext.FinancialOperations
            .Include(operation => operation.FinanceType)
            .Where(operation => operation.DateModified.Date >= fromDate.Date && operation.DateModified.Date <= toDate.Date)
            .AsSplitQuery();

        if (transactionType is not null)
        {
            financialOperationsQuery = financialOperationsQuery.Where(operation => operation.FinanceType.TransactionType == transactionType);
        }

        if (!string.IsNullOrWhiteSpace(currency))
        {
            financialOperationsQuery = financialOperationsQuery.Where(operation => operation.Money.Currency == currency);
        }

        return await financialOperationsQuery.CountAsync(cancellationToken);
    }

    public async Task<decimal> GetDailyAmount(
        DateTime startDate,
        DateTime endDate,
        string currency,
        TransactionDirection transactionType,
        CancellationToken token)
    {
        decimal amount = await _dbContext.FinancialOperations
            .Include(operation => operation.FinanceType)
            .Where(operation => operation.DateCreated.Date >= startDate.Date &&
                operation.DateCreated.Date <= endDate.Date &&
                operation.FinanceType.TransactionType == transactionType &&
                operation.Money.Currency == currency)
            .AsSplitQuery()
            .SumAsync(operation => operation.Money.Amount, token);

        return amount;
    }
}
