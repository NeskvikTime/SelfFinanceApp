namespace SelfFinanceApp.Domain.Contracts
{
    public interface IDateTimeProvider
    {
        public DateTime UtcNow { get; }
    }
}
