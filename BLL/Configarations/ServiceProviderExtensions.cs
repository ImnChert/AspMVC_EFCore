using BLL.Mappings;
using BLL.Services.AnimalService;
using BLL.Services.HuntingSeasonService;
using DAL.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Configarations
{
    public static class ServiceProviderExtensions
    {
        public static void AddConfigureBLL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddConfigureDAL(configuration);

            services.AddAutoMapping();

            services.AddServices();
        }

        private static void AddAutoMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(AnimalProfile),
                typeof(HuntingSeasonProfile)
                );
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAnimalService, AnimalService>();
            services.AddScoped<IHuntingSeasonService, HuntingSeasonService>();
        }
    }
}
