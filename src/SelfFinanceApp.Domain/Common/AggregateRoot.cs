namespace SelfFinanceApp.Domain.Common
{
    public class AggregateRoot : BaseEntity
    {
        protected AggregateRoot(Guid id) : base(id) 
        { 
        
        }

        protected AggregateRoot() { }
    }
}
