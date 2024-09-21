using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using SelfFinanceApp.Persistance.DatabaseContext;

namespace SelfFinanceApp.Persistance.Health
{
    internal class DatabaseHealthCheck : IHealthCheck
    {
        public const string Name = "Database";

        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<DatabaseHealthCheck> _logger;

        public DatabaseHealthCheck(ApplicationDbContext dbContext, ILogger<DatabaseHealthCheck> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken)
        {
            try
            {
                _ = await _dbContext.Database.CanConnectAsync(cancellationToken);
                return HealthCheckResult.Healthy();
            }
            catch (Exception e)
            {
                string message = "Database is unhealthy";
                _logger.LogError(message, e);
                return HealthCheckResult.Unhealthy(message);
            }
        }
    }
}
