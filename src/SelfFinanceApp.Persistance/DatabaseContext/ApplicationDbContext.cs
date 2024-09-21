using Microsoft.EntityFrameworkCore;
using SelfFinanceApp.Domain.Aggregates;
using SelfFinanceApp.Domain.Common;
using SelfFinanceApp.Domain.Contracts;
using SelfFinanceApp.Domain.Contracts.Repositories;
using SelfFinanceApp.Domain.Entities;
using SelfFinanceApp.Persistance.Extensions;

namespace SelfFinanceApp.Persistance.DatabaseContext;

internal class ApplicationDbContext : DbContext, IDatabaseMigrator
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public ApplicationDbContext(DbContextOptions options, IDateTimeProvider dateTimeProvider) : base(options)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public DbSet<FinancialType> FinancialTypes => Set<FinancialType>();
    public DbSet<FinancialOperation> FinancialOperations => Set<FinancialOperation>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.SeedDataBase();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        DateTime now;

        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>())
        {
            now = _dateTimeProvider.UtcNow;

            entry.Entity.DateModified = now;

            if (entry.State == EntityState.Added)
            {
                entry.Entity.DateCreated = now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    public void Migrate()
    {
        base.Database.Migrate();
    }
}
