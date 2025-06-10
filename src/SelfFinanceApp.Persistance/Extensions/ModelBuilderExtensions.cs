using Microsoft.EntityFrameworkCore;
using SelfFinanceApp.Domain.Aggregates;
using SelfFinanceApp.Domain.Entities;
using SelfFinanceApp.Domain.Enums;

namespace SelfFinanceApp.Persistance.Extensions;

public static class ModelBuilderExtension
{
    public static void SeedDataBase(this ModelBuilder modelBuilder)
    {
        // Use static GUIDs and DateTimes for seeding
        var billTypeId = new Guid("11111111-1111-1111-1111-111111111111");
        var rentTypeId = new Guid("22222222-2222-2222-2222-222222222222");
        var salaryTypeId = new Guid("33333333-3333-3333-3333-333333333333");
        var dividendTypeId = new Guid("44444444-4444-4444-4444-444444444444");

        var staticDate = new DateTime(2023, 6, 1, 0, 0, 0, DateTimeKind.Utc);
        var staticDate2 = new DateTime(2023, 7, 1, 0, 0, 0, DateTimeKind.Utc);
        var staticDate3 = new DateTime(2023, 8, 1, 0, 0, 0, DateTimeKind.Utc);
        var staticDate4 = new DateTime(2023, 9, 1, 0, 0, 0, DateTimeKind.Utc);

        var billType = new FinancialType("Bills", TransactionDirection.Expense)
        {
            Id = billTypeId,
            DateCreated = staticDate,
            DateModified = staticDate
        };
        var rentType = new FinancialType("Rent", TransactionDirection.Expense)
        {
            Id = rentTypeId,
            DateCreated = staticDate,
            DateModified = staticDate
        };
        var salaryType = new FinancialType("Salary", TransactionDirection.Income)
        {
            Id = salaryTypeId,
            DateCreated = staticDate,
            DateModified = staticDate
        };
        var dividendType = new FinancialType("Dividends", TransactionDirection.Income)
        {
            Id = dividendTypeId,
            DateCreated = staticDate,
            DateModified = staticDate
        };

        // Seed FinancialType first
        modelBuilder.Entity<FinancialType>()
            .HasData(billType, rentType, salaryType, dividendType);

        // For owned entities, seed using anonymous objects with the owned properties
        var operations = new[]
        {
            new
            {
                Id = new Guid("10000000-0000-0000-0000-000000000001"),
                Name = "Paying bills 06-2023",
                Description = (string?)null,
                DateCreated = staticDate,
                DateModified = staticDate,
                FinanceTypeId = billTypeId,
                Money_Amount = 1000M,
                Money_Currency = "EUR"
            },
            new
            {
                Id = new Guid("10000000-0000-0000-0000-000000000002"),
                Name = "Paying rent 06-2023",
                Description = (string?)null,
                DateCreated = staticDate,
                DateModified = staticDate,
                FinanceTypeId = rentTypeId,
                Money_Amount = 1000M,
                Money_Currency = "EUR"
            },
            new
            {
                Id = new Guid("10000000-0000-0000-0000-000000000003"),
                Name = "Salary 06-2023",
                Description = (string?)null,
                DateCreated = staticDate,
                DateModified = staticDate,
                FinanceTypeId = salaryTypeId,
                Money_Amount = 3000M,
                Money_Currency = "EUR"
            },
            new
            {
                Id = new Guid("10000000-0000-0000-0000-000000000004"),
                Name = "Dividend 06-2023",
                Description = (string?)null,
                DateCreated = staticDate,
                DateModified = staticDate,
                FinanceTypeId = dividendTypeId,
                Money_Amount = 100M,
                Money_Currency = "EUR"
            },
            new
            {
                Id = new Guid("10000000-0000-0000-0000-000000000005"),
                Name = "Paying bills 07-2023",
                Description = (string?)null,
                DateCreated = staticDate2,
                DateModified = staticDate2,
                FinanceTypeId = billTypeId,
                Money_Amount = 1000M,
                Money_Currency = "EUR"
            },
            new
            {
                Id = new Guid("10000000-0000-0000-0000-000000000006"),
                Name = "Paying rent 07-2023",
                Description = (string?)null,
                DateCreated = staticDate2,
                DateModified = staticDate2,
                FinanceTypeId = rentTypeId,
                Money_Amount = 1000M,
                Money_Currency = "EUR"
            },
            new
            {
                Id = new Guid("10000000-0000-0000-0000-000000000007"),
                Name = "Salary 07-2023",
                Description = (string?)null,
                DateCreated = staticDate2,
                DateModified = staticDate2,
                FinanceTypeId = salaryTypeId,
                Money_Amount = 3000M,
                Money_Currency = "EUR"
            },
            new
            {
                Id = new Guid("10000000-0000-0000-0000-000000000008"),
                Name = "Dividend 07-2023",
                Description = (string?)null,
                DateCreated = staticDate2,
                DateModified = staticDate2,
                FinanceTypeId = dividendTypeId,
                Money_Amount = 100M,
                Money_Currency = "EUR"
            },
            new
            {
                Id = new Guid("10000000-0000-0000-0000-000000000009"),
                Name = "Paying bills 08-2023",
                Description = (string?)null,
                DateCreated = staticDate3,
                DateModified = staticDate3,
                FinanceTypeId = billTypeId,
                Money_Amount = 1000M,
                Money_Currency = "EUR"
            },
            new
            {
                Id = new Guid("10000000-0000-0000-0000-00000000000a"),
                Name = "Paying rent 08-2023",
                Description = (string?)null,
                DateCreated = staticDate3,
                DateModified = staticDate3,
                FinanceTypeId = rentTypeId,
                Money_Amount = 1000M,
                Money_Currency = "EUR"
            },
            new
            {
                Id = new Guid("10000000-0000-0000-0000-00000000000b"),
                Name = "Salary 08-2023",
                Description = (string?)null,
                DateCreated = staticDate3,
                DateModified = staticDate3,
                FinanceTypeId = salaryTypeId,
                Money_Amount = 3000M,
                Money_Currency = "EUR"
            },
            new
            {
                Id = new Guid("10000000-0000-0000-0000-00000000000c"),
                Name = "Dividend 08-2023",
                Description = (string?)null,
                DateCreated = staticDate3,
                DateModified = staticDate3,
                FinanceTypeId = dividendTypeId,
                Money_Amount = 100M,
                Money_Currency = "EUR"
            },
            new
            {
                Id = new Guid("10000000-0000-0000-0000-00000000000d"),
                Name = "Paying bills 09-2023",
                Description = (string?)null,
                DateCreated = staticDate4,
                DateModified = staticDate4,
                FinanceTypeId = billTypeId,
                Money_Amount = 1000M,
                Money_Currency = "EUR"
            },
            new
            {
                Id = new Guid("10000000-0000-0000-0000-00000000000e"),
                Name = "Paying rent 09-2023",
                Description = (string?)null,
                DateCreated = staticDate4,
                DateModified = staticDate4,
                FinanceTypeId = rentTypeId,
                Money_Amount = 1000M,
                Money_Currency = "EUR"
            }
        };

        modelBuilder.Entity<FinancialOperation>().HasData(operations);
    }
}
