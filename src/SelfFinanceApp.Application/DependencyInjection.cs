using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SelfFinanceApp.Application.FinancialOperations.Commands.Create;

namespace SelfFinanceApp.Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddValidatorsFromAssemblyContaining<CreateFinancialOperationCommandValidator>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        }
    }
}
