using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Conductor.Entities
{
    public class ApplicationContext : IdentityDbContext
    {
        public DbSet<Ensemble> Ensembles { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Composition> Compositions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=conductor.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Ensemble>()
                .HasIndex(e => e.Key)
                .IsUnique();

            builder.Entity<Artist>()
                .HasIndex(a => a.Key)
                .IsUnique();

            builder.Entity<Composition>()
                .HasIndex(a => a.Key)
                .IsUnique();
        }
    }
}
