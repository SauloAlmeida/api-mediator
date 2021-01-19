using Microsoft.Extensions.DependencyInjection;

namespace ApiMediator.App.Infrastructure.Configuration
{
    public static class MediatorSetup
    {
        public static void AddService(IServiceCollection services)
        {
            services.AddMediator(opt => opt.AddHandlersFromAssemblyOf<Startup>());
        }
    }
}
