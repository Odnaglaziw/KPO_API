using Core.Models;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(Employee.MAX_LENGTH)
                .IsRequired();
            builder.Property(e => e.LastName)
                .HasMaxLength(Employee.MAX_LENGTH)
                .IsRequired();
            builder.Property(e => e.Login).IsRequired();
            builder.Property(e => e.Password).IsRequired();
        }
    }
}
