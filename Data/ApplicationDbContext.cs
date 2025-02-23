using Microsoft.EntityFrameworkCore;

namespace firstback.user
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
       base(options)
        {

        }

        // Tabla Users
        public DbSet<User> Users { get; set; }
    }
}

