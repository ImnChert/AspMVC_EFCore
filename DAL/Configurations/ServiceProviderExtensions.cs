using DAL.Repositories.AnimalRepository;
using DAL.Repositories.HuntingSeasonRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Configurations
{
    public static class ServiceProviderExtensions
    {
        public static void AddConfigureDAL(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<ApplicationContext>(options =>
            //   options.UseSqlServer(connectionString));

            //services.AddDbContext<ApplicationContext>();

            services.ConfigurationMSSQLServer(configuration);

            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<IHuntingSeasonRepository, HuntingSeasonRepository>();
        }

        private static void ConfigurationMSSQLServer(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("DAL")));
        }
    }
}
