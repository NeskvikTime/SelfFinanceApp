using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelfFinanceApp.Domain.Aggregates;

namespace SelfFinanceApp.Persistance.Configurations
{
    public class FinancialOperationConfiguration : IEntityTypeConfiguration<FinancialOperation>
    {
        public void Configure(EntityTypeBuilder<FinancialOperation> builder)
        {
            builder
                .HasKey(financialOperation => financialOperation.Id);

            builder
                .HasIndex(financialOperation => financialOperation.Name)
                .IsUnique();

            builder
                .OwnsOne(financialOperation => financialOperation.Money)
                .Property(p => p.Amount)
                .HasColumnName("Amount")
                .HasPrecision(18, 2);

            builder
                .OwnsOne(financialOperation => financialOperation.Money)
                .Property(p => p.Currency)
                .HasColumnName("Currency")
                .HasMaxLength(3);

            builder
                .HasOne(financialOperation => financialOperation.FinanceType)
                .WithMany(type => type.FinancialOperations)
                .HasForeignKey(p => p.FinanceTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
