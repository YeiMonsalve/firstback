using firstback.bootcamps;
using firstback.categorias;
using firstback.roles;
using firstback.user;
using FIRSTBACK.BootcampsTematicas;
using FIRSTBACK.Instituciones;
using FIRSTBACK.Oportunidades;
using FIRSTBACK.Tematicas;
using Microsoft.EntityFrameworkCore;
using Users_Opportunities.Models;
using Institutions_Opportunity.Models;


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
        public DbSet<InstitutionOpportunity> InstitutionOpportunities { get; set; }
        public DbSet<Oportunidad> Oportunidades { get; set; }
        public DbSet<Institucion> Instituciones { get; set; }
        public DbSet<Bootcamp> Bootcamps { get; set; }
        public DbSet<BootcampTematica> BootcampTematicas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserOpportunity>()
                .HasKey(uo => new { uo.userId, uo.opportunityId });

            modelBuilder.Entity<InstitutionOpportunity>()
                .HasKey(io => new { io.institutionId, io.opportunityId });
             
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users);

            modelBuilder.Entity<Bootcamp>()
                .HasOne(b => b.Institucion)
                .WithMany(t => t.bootcamps);

            modelBuilder.Entity<BootcampTematica>()
            .HasKey(bt => new { bt.IdBootcamp, bt.IdTematica });

            modelBuilder.Entity<Oportunidad>()
            .HasKey(o => o.id);

            modelBuilder.Entity<Oportunidad>(entity => {
                entity.HasKey(o => o.id);
                entity.Property(o => o.nombre).HasMaxLength(255);
                //entity.HasOne(o=> o.Institucion)
            });


        }
    }
}

