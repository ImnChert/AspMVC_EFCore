using BLL.Mappings;
using BLL.Services.AnimalService;
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

            services.AddAutoMapper(typeof(AnimalProfile), typeof(HuntingSeasonProfile),
                typeof(InfoAnimalProfile), typeof(InfoHuntingSeasonProfile));

            services.AddScoped<IAnimalService, AnimalService>();

        }
    }
}
