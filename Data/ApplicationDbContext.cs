using FIRSTBACK.Tematicas;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Tematica> Tematicas { get; set; }
    }

}
