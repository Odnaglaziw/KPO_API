using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class AccountingConfiguration : IEntityTypeConfiguration<AccountingEntity>
    {
        public void Configure(EntityTypeBuilder<AccountingEntity> builder)
        {
            builder.HasKey(a => a.Id);

            builder
            .HasOne<StoreEntity>()      
            .WithMany()                 
            .HasForeignKey(a => a.StoreId) 
            .OnDelete(DeleteBehavior.Restrict);

            builder.Property(a => a.Description)
            .HasMaxLength(200);
        }
    }
}
