using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class KpoDbContext : DbContext
    {
        public KpoDbContext(DbContextOptions<KpoDbContext> options):base(options) { }
        
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<StoreEntity> Stores { get; set; }
        public DbSet<AttendanceEntity> Attendances { get; set; }
        public DbSet<AccountingEntity> Accountings { get; set; }
    }
}
