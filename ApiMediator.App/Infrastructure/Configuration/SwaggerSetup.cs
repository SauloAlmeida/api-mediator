using Microsoft.AspNetCore.Builder;

namespace ApiMediator.App.Infrastructure.Configuration
{
    public static class SwaggerSetup
    {
        public static void AddConfigure(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Mediator");
            });
        }
    }
}
