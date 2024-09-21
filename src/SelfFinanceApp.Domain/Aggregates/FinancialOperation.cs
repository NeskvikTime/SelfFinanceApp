using SelfFinanceApp.Domain.Common;
using SelfFinanceApp.Domain.Entities;
using SelfFinanceApp.Domain.ValueObjects;

namespace SelfFinanceApp.Domain.Aggregates
{
    public class FinancialOperation : AggregateRoot
    {
        public string Name { get; set; }
        public MonetaryValue Money { get; set; }
        public FinancialType FinanceType { get; set; } = null!;
        public Guid FinanceTypeId { get; set; }

        public FinancialOperation(
            string name,
            MonetaryValue money,
            Guid financeTypeId,
            Guid? id = null) : base(id ?? Guid.NewGuid())
        {
            Name = name;
            Money = money;
            FinanceTypeId = financeTypeId;
        }

        public void WithMonetaryValue(MonetaryValue money)
        {
            Money = money;
        }

        public void ChangeName(string newName)
        {
            Name = newName;
        }

        public void ChangeFinanceTypeId(Guid financeTypeId)
        {
            FinanceTypeId = financeTypeId;
            FinanceType = null;
        }

        private FinancialOperation() { }
    }
}
