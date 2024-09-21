namespace SelfFinanceApp.Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; init; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public override bool Equals(object? other)
        {
            if(other is null || other.GetType() != GetType())
            {
                return false;
            }

            return ((BaseEntity)other).Id == Id;
        }

        public override int GetHashCode() => Id.GetHashCode();

        protected BaseEntity(Guid id) => Id = id;
        protected BaseEntity() { }
    }
}
