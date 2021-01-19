using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiMediator.App.Infrastructure.Configuration
{
    public static class AppSettingsSetup
    {
        public static void AddSettingsSetup(this IServiceCollection services, IConfiguration configuration)
        {
            // services.Configure<class>(configuration.GetSection(nmaeof(class)));
        }
    }
}
