using SelfFinanceApp.Domain.Common;
using SelfFinanceApp.Domain.Enums;
using SelfFinanceApp.Domain.Aggregates;

namespace SelfFinanceApp.Domain.Entities
{
    public class FinancialType : BaseEntity
    {
        public string Name { get; set; } = default!;

        public TransactionDirection TransactionType { get; set; }

        public virtual List<FinancialOperation> FinancialOperations { get; set; } = new List<FinancialOperation>();

        public FinancialType(string name, TransactionDirection transactionType, Guid? id = null) : base(id ?? Guid.NewGuid())
        {
            Name = name;
            TransactionType = transactionType;
        }

        private FinancialType() { }

        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty", nameof(name));
            }

            Name = name;
        }

        public void ChangeDirectionType(TransactionDirection directionType)
        {
            TransactionType = directionType;
        }
    }
}
