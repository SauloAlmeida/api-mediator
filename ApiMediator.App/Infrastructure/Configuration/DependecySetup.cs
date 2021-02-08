using ApiMediator.App.Infrastructure.Data.EventContext;
using Microsoft.Extensions.DependencyInjection;

namespace ApiMediator.App.Infrastructure.Configuration
{
    public static class DependecySetup
    {
        public static void Handle(IServiceCollection service)
        {
            service.AddTransient<IEventContext, EventContext>(); // on request - for every dependecy injection is create a new instance
        }
    }
}
