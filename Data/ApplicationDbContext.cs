using Microsoft.EntityFrameworkCore;

namespace BackendProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Bootcamp> Bootcamps { get; set; }
    }
}