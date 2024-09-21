using SelfFinanceApp.Domain.ValueObjects;

namespace SelfFinanceApp.Tests.Shared.Builders
{
    public class MonetaryValueBuilder
    {
        private decimal _amount = 100;
        private string _currency = "USD";

        public MonetaryValueBuilder WithAmount(decimal amount)
        {
            _amount = amount;
            return this;
        }

        public MonetaryValueBuilder WithCurrency(string currency)
        {
            _currency = currency;
            return this;
        }

        public MonetaryValue Build()
        {
            return new MonetaryValue(_amount, _currency);
        }
    }
}
