using DAL.Repositories.AnimalRepository;
using DAL.Repositories.HuntingSeasonRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Configurations
{
    public static class ServiceProviderExtensions
    {
        public static void AddConfigureDAL(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationContext>(options =>
               options.UseSqlServer(connectionString));

            //services.AddScoped<ApplicationContext>();
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<IHuntingSeasonRepository, HuntingSeasonRepository>();
        }
    }
}
