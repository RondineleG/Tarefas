using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Tarefas.API.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(cfg =>
            {
                cfg.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Tarefas API",
                    Version = "v1",
                    Description = "Api para cadastro de tarefas",
                    Contact = new OpenApiContact
                    {
                        Name = "Rondinele Guimarães",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                    },
                });
            });
            return services;
        }

        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger().UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Tarefas API");
                options.DocumentTitle = "Tarefas API";
            });
            return app;
        }
    }
}
