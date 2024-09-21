using Microsoft.EntityFrameworkCore;
using SelfFinanceApp.Domain.Aggregates;
using SelfFinanceApp.Domain.Entities;
using SelfFinanceApp.Domain.Enums;
using SelfFinanceApp.Domain.ValueObjects;

namespace SelfFinanceApp.Persistance.Extensions;

public static class ModelBuilderExtension
{
    public static void SeedDataBase(this ModelBuilder modelBuilder)
    {
        FinancialType billType = new FinancialType("Bills", TransactionDirection.Expense) { DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow };
        FinancialType rentType = new FinancialType("Rent", TransactionDirection.Expense) { DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow };
        FinancialType salaryType = new FinancialType("Salary", TransactionDirection.Income) { DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow };
        FinancialType dividendType = new FinancialType("Dividends", TransactionDirection.Income) { DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow };

        MonetaryValue monetaryValueBill = new MonetaryValue(1000M, "EUR");
        MonetaryValue monetaryValueRent = new MonetaryValue(1000M, "EUR");
        MonetaryValue monetaryValueSalary = new MonetaryValue(3000M, "EUR");
        MonetaryValue monetaryValueDividend = new MonetaryValue(100M, "EUR");

        // Seed data for FinancialType
        modelBuilder.Entity<FinancialType>().HasData(new List<FinancialType>
        {
            billType,
            rentType,
            salaryType,
            dividendType
        });

        FinancialOperation operation1 = new FinancialOperation("Paying bills 06-2023", null, billType.Id) { DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow };
        FinancialOperation operation2 = new FinancialOperation("Paying rent 06-2023", null, rentType.Id) { DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow };
        FinancialOperation operation3 = new FinancialOperation("Salary 06-2023", null, salaryType.Id) { DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow };
        FinancialOperation operation4 = new FinancialOperation("Dividend 06-2023", null, dividendType.Id) { DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow };
        FinancialOperation operation5 = new FinancialOperation("Paying bills 07-2023", null, billType.Id) { DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow };
        FinancialOperation operation6 = new FinancialOperation("Paying rent 07-2023", null, rentType.Id) { DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow };
        FinancialOperation operation7 = new FinancialOperation("Salary 07-2023", null, salaryType.Id) { DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow };
        FinancialOperation operation8 = new FinancialOperation("Dividend 07-2023", null, dividendType.Id) { DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow };
        FinancialOperation operation9 = new FinancialOperation("Paying bills 08-2023", null, billType.Id) { DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow };
        FinancialOperation operation10 = new FinancialOperation("Paying rent 08-2023", null, rentType.Id) { DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow };
        FinancialOperation operation11 = new FinancialOperation("Salary 08-2023", null, salaryType.Id) { DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow };
        FinancialOperation operation12 = new FinancialOperation("Dividend 08-2023", null, dividendType.Id) { DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow };
        FinancialOperation operation13 = new FinancialOperation("Paying bills 09-2023", null, billType.Id) { DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow };
        FinancialOperation operation14 = new FinancialOperation("Paying rent 09-2023", null, rentType.Id) { DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow };


        modelBuilder.Entity<FinancialOperation>().HasData(
            operation1,
            operation2,
            operation3,
            operation4,
            operation5,
            operation6,
            operation7,
            operation8,
            operation9,
            operation10,
            operation11,
            operation12,
            operation13,
            operation14);

        modelBuilder.Entity<FinancialOperation>().OwnsOne(e => e.Money).HasData(new
        {
            FinancialOperationId = operation1.Id,
            Amount = monetaryValueBill.Amount,
            Currency = monetaryValueBill.Currency
        },

        new
        {
            FinancialOperationId = operation2.Id,
            Amount = monetaryValueRent.Amount,
            Currency = monetaryValueRent.Currency
        },

        new
        {
            FinancialOperationId = operation3.Id,
            Amount = monetaryValueSalary.Amount,
            Currency = monetaryValueSalary.Currency
        },

        new
        {
            FinancialOperationId = operation4.Id,
            Amount = monetaryValueDividend.Amount,
            Currency = monetaryValueDividend.Currency
        },
        new
        {
            FinancialOperationId = operation5.Id,
            Amount = monetaryValueBill.Amount,
            Currency = monetaryValueBill.Currency
        },
        new
        {
            FinancialOperationId = operation6.Id,
            Amount = monetaryValueRent.Amount,
            Currency = monetaryValueRent.Currency
        },
        new
        {
            FinancialOperationId = operation7.Id,
            Amount = monetaryValueRent.Amount,
            Currency = monetaryValueRent.Currency
        },
        new
        {
            FinancialOperationId = operation8.Id,
            Amount = monetaryValueRent.Amount,
            Currency = monetaryValueRent.Currency
        },
        new
        {
            FinancialOperationId = operation9.Id,
            Amount = monetaryValueRent.Amount,
            Currency = monetaryValueRent.Currency
        },
        new
        {
            FinancialOperationId = operation10.Id,
            Amount = monetaryValueRent.Amount,
            Currency = monetaryValueRent.Currency
        },
        new
        {
            FinancialOperationId = operation11.Id,
            Amount = monetaryValueRent.Amount,
            Currency = monetaryValueRent.Currency
        },
        new
        {
            FinancialOperationId = operation12.Id,
            Amount = monetaryValueRent.Amount,
            Currency = monetaryValueRent.Currency
        },
        new
        {
            FinancialOperationId = operation13.Id,
            Amount = monetaryValueRent.Amount,
            Currency = monetaryValueRent.Currency
        },
        new
        {
            FinancialOperationId = operation14.Id,
            Amount = monetaryValueRent.Amount,
            Currency = monetaryValueRent.Currency
        });
    }
}
