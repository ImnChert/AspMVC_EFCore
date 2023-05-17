using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Configurations
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<HuntingSeason> HuntingSeasons { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
            });
        }
    }
}