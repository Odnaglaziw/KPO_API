using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<AttendanceEntity>
    {
        public void Configure(EntityTypeBuilder<AttendanceEntity> builder)
        {
            builder.HasKey(a => a.Id);

            builder
            .HasOne<AccountingEntity>()
            .WithMany()                
            .HasForeignKey(a => a.AccountingId)
            .OnDelete(DeleteBehavior.Cascade);

            builder
            .HasOne<EmployeeEntity>()
            .WithMany()              
            .HasForeignKey(a => a.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Property(a => a.ArrivalCode)
            .IsRequired()
            .HasMaxLength(3);
        }
    }
}
