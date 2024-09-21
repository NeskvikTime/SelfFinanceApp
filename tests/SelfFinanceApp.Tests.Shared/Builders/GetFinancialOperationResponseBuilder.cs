using SelfFinanceApp.Domain.Enums;
using SelfFinanceApp.Domain.Responses.FinancialOperations;

namespace SelfFinanceApp.Tests.Shared.Builders
{
    public class GetFinancialOperationResponseBuilder
    {
        private Guid _id = Guid.NewGuid();
        private string _name = "Default Operation Name";
        private decimal _amount = 100.00m;
        private string _currency = "USD";
        private Guid _financialTypeId = Guid.NewGuid();
        private string _financialTypeName = "Default Financial Type Name";
        private DateOnly _date = DateOnly.FromDateTime(DateTime.Now);
        private TransactionDirection _directionType = TransactionDirection.Income;

        public GetFinancialOperationResponseBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public GetFinancialOperationResponseBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public GetFinancialOperationResponseBuilder WithAmount(decimal amount)
        {
            _amount = amount;
            return this;
        }

        public GetFinancialOperationResponseBuilder WithCurrency(string currency)
        {
            _currency = currency;
            return this;
        }

        public GetFinancialOperationResponseBuilder WithFinancialTypeId(Guid financialTypeId)
        {
            _financialTypeId = financialTypeId;
            return this;
        }

        public GetFinancialOperationResponseBuilder WithFinancialTypeName(string financialTypeName)
        {
            _financialTypeName = financialTypeName;
            return this;
        }

        public GetFinancialOperationResponseBuilder WithDate(DateOnly date)
        {
            _date = date;
            return this;
        }

        public GetFinancialOperationResponseBuilder WithDirectionType(TransactionDirection directionType)
        {
            _directionType = directionType;
            return this;
        }

        public GetFinancialOperationResponse Build()
        {
            return new GetFinancialOperationResponse(
                _id,
                _name,
                _amount,
                _currency,
                _financialTypeId,
                _financialTypeName,
                _date,
                _directionType
            );
        }
    }

}
