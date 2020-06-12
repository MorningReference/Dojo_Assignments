using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Models
{
    public class CRUDeliciousContext : DbContext
    {
        public CRUDeliciousContext(DbContextOptions options) : base(options) { }

        public DbSet<Dishes> Dishes { get; set; }
        public DbSet<Chef> Chefs { get; set; }
    }
}