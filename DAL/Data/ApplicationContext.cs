using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Configurations
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<HuntingSeason> HuntingSeasons { get; set; }
    }
}
