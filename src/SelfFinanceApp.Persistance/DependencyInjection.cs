using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SelfFinanceApp.Domain.Common;
using SelfFinanceApp.Domain.Contracts;
using SelfFinanceApp.Domain.Contracts.Repositories;
using SelfFinanceApp.Persistance.DatabaseContext;
using SelfFinanceApp.Persistance.Health;
using SelfFinanceApp.Persistance.Repositories;

namespace SelfFinanceApp.Persistance;

public static class DependencyInjection
{
    public static void AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IDatabaseMigrator, ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                npgsqlOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorCodesToAdd: null);
                });
        });

        //Add Repositories
        services.AddScoped<IFinancialTypesRepository, FinancialTypesRepository>();
        services.AddScoped<IFinancialOperationsRepository, FinancialOperationsRepository>();
        services.AddScoped<IDateTimeProvider, SystemDateTimeProvider>();
        
        services.AddHealthChecks()
            .AddNpgSql(configuration.GetConnectionString("DefaultConnection")!,
                name: DatabaseHealthCheck.Name,
                tags: new[] { "ready" });
    }
}