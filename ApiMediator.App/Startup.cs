using ApiMediator.App.Infrastructure.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApiMediator
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen();

            DependecySetup.Handle(services);
    
            AppSettingsSetup.Handle(services, Configuration);

            DatabaseSetup.Handle(services);

            MediatorSetup.Handle(services);

            MiddlewareSetup.Handle(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            SwaggerSetup.Handle(app);

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
