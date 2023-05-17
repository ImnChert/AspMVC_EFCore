using DAL.Repositories.AnimalRepository;
using DAL.Repositories.HuntingSeasonRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Configurations
{
    public static class ServiceProviderExtensions
    {
        public static void AddConfigureDAL(this IServiceCollection service, IConfiguration configuration)
        {
            service.ConfigurationMSSQLServer(configuration);

            service.AddRepositories();
        }

        private static void ConfigurationMSSQLServer(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("DAL")));
        }

        private static void AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<IAnimalRepository, AnimalRepository>();
            service.AddScoped<IHuntingSeasonRepository, HuntingSeasonRepository>();
        }
    }
}
