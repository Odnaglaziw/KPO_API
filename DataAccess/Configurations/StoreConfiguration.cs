using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class StoreConfiguration : IEntityTypeConfiguration<StoreEntity>
    {
        public void Configure(EntityTypeBuilder<StoreEntity> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Address).IsRequired();
        }
    }
}
