using Identity.Data;
using Identity.Entities;
using Identity.Repositories.AccountRepositories;
using Identity.Repositories.UserRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Configurations
{
    public static class ServiceProviderExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services, IConfiguration configuration)
        {

            services.ConfigurationMSSQLServer(configuration);

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        private static void ConfigurationMSSQLServer(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Identity")))
                .AddIdentity<ApplicationUser, ApplicationRole>(opt =>
                {
                    opt.SignIn.RequireConfirmedAccount = false;
                    opt.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<IdentityContext>();
        }
    }
}
