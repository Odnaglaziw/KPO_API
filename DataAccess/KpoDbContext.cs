using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class KpoDbContext : DbContext
    {
        public KpoDbContext(DbContextOptions<KpoDbContext> options):base(options) { }
        
    }
}
