using ApiMediator.App.Middleware;
using Microsoft.Extensions.DependencyInjection;

namespace ApiMediator.App.Infrastructure.Configuration
{
    public static class MiddlewareSetup
    {
        public static void Handle(IServiceCollection service)
        {
            service.AddMvc(options =>
            {
                options.Filters.Add<ExceptionMiddleware>();
            });
        }
    }
}
