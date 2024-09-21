using SelfFinanceApp.Domain.Contracts;

namespace SelfFinanceApp.Domain.Common
{
    public class SystemDateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
