using Microsoft.Extensions.DependencyInjection;
using SelfFinanceApp.Domain.Contracts.Services;
using SelfFinanceApp.Infrastructure.Services;

namespace SelfFinanceApp.Infrastructure
{
    public static class DependencyInjection
    {

        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            // Add Infrastructure Services
            services.AddScoped<IFinancialTypesService, FinancialTypesService>();
            services.AddScoped<IFinancialOperationsService, FinancialOperationsService>();
        }
    }
}
