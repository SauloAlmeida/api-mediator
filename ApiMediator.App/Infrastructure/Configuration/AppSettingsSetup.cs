using ApiMediator.App.Infrastructure.AppSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiMediator.App.Infrastructure.Configuration
{
    public static class AppSettingsSetup
    {
        public static void Handle(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStrings>(configuration.GetSection(nameof(ConnectionStrings)));
        }
    }
}
