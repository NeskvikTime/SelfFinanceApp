using SelfFinanceApp.Domain.Common;

namespace SelfFinanceApp.Domain.ValueObjects
{
    public class MonetaryValue : ValueObject
    {
        private static readonly IReadOnlyCollection<string> AllowedCurrencies = new List<string> { "EUR", "USD" };

        public decimal Amount { get; init; }

        public string Currency { get; init; }

        public MonetaryValue(decimal amount, string currency)
        {
            if (string.IsNullOrWhiteSpace(currency))
            {
                throw new ArgumentNullException(nameof(currency));
            }

            if (!AllowedCurrencies.Contains(currency.ToUpperInvariant()))
            {
                throw new ArgumentException($"Parameter {nameof(currency)} should contain only one of the following currencies: {string.Join(", ", AllowedCurrencies)}");
            }

            Amount = amount;
            Currency = currency.ToUpperInvariant();
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }

        public static bool CurrencyIsValid(string currencyName)
        {
            if (string.IsNullOrWhiteSpace(currencyName))
            {
                return false;
            }

            bool result = AllowedCurrencies.Contains(currencyName.ToUpperInvariant());

            return result;
        }
    }
}
