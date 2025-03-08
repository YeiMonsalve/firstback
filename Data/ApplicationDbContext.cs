using firstback.bootcamps;
using firstback.categorias;
using firstback.roles;
using firstback.user;
using FIRSTBACK.BootcampsTematicas;
using FIRSTBACK.Instituciones;
using FIRSTBACK.Tematicas;
using Microsoft.EntityFrameworkCore;
using Users_Opportunities.Models;
using firstback.roles;
using firstback.categorias;
using firstback.user;
using firstback.bootcamps;
using FIRSTBACK.BootcampsTematicas;

namespace BackendProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Roles> Roles { get; set; }
        public DbSet<Tematica> Tematicas { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOpportunity> UsersOpportunities { get; set; }

        public DbSet<Institucion> Instituciones { get; set; }
        public DbSet<Bootcamp> Bootcamps { get; set; }
        public DbSet<BootcampTematica> BootcampTematicas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserOpportunity>()
                .HasKey(uo => new { uo.userId, uo.opportunityId });

          /*  modelBuilder.Entity<UserOpportunity>()
                .HasOne(uo => uo.User)
                .WithMany(uo => uo.userId)
                .HasForeignKey(uo => uo.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Recomendado: Evita borrados en cascada
 // Recomendado: Evita borrados en cascada*/

        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users);

            modelBuilder.Entity<Bootcamp>()
                .HasOne(b => b.Institucion)
                .WithMany(t => t.bootcamps);

            modelBuilder.Entity<BootcampTematica>()
            .HasKey(bt => new { bt.IdBootcamp, bt.IdTematica });
        }
    
        }
    }
}

