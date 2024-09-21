using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SelfFinanceApp.Domain.Entities;

namespace SelfFinanceApp.Persistance.Configurations
{
    public class FinancialTypeConfiguration : IEntityTypeConfiguration<FinancialType>
    {
        public void Configure(EntityTypeBuilder<FinancialType> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .HasIndex(financialType => financialType.Name)
                .IsUnique();

            builder.HasMany(p => p.FinancialOperations)
                .WithOne(p => p.FinanceType)
                .HasForeignKey(p => p.FinanceTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
