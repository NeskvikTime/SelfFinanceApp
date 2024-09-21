using SelfFinanceApp.Domain.ValueObjects;
using SelfFinanceApp.Tests.Shared.Builders;

namespace SelfFinanceApp.Domain.Tests
{
    public class MonetaryValueTests
    {
        [Fact]
        public void Constructor_ShouldCreateValidObject()
        {
            // Arrange
            var expectedAmount = 100m;
            var expectedCurrency = "USD";

            // Act
            var monetaryValue = new MonetaryValueBuilder()
                .WithAmount(expectedAmount)
                .WithCurrency(expectedCurrency)
                .Build();

            // Assert
            monetaryValue.Amount.Should().Be(expectedAmount);
            monetaryValue.Currency.Should().Be(expectedCurrency);
        }

        [Theory]
        [InlineData("USD", true)]
        [InlineData("EUR", true)]
        [InlineData("JPY", false)]
        [InlineData("GBP", false)]
        [InlineData("", false)]
        public void CurrencyIsValid_ShouldReturnCorrectValue(string currency, bool expectedResult)
        {
            // Act
            var result = MonetaryValue.CurrencyIsValid(currency);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("USD")]
        [InlineData("EUR")]
        public void Constructor_ShouldAcceptValidCurrencies(string currency)
        {
            // Act
            Action act = () => new MonetaryValueBuilder()
                .WithCurrency(currency)
                .Build();

            // Assert
            act.Should().NotThrow();
        }

        [Theory]
        [InlineData("JPY")]
        [InlineData("GBP")]
        public void Constructor_ShouldThrowOnInvalidCurrencies(string currency)
        {
            // Act
            Action act = () => new MonetaryValueBuilder()
                .WithCurrency(currency)
                .Build();

            // Assert
            act.Should().Throw<ArgumentException>();
        }
    }
}
