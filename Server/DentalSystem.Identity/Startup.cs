namespace DentalSystem.Identity
{
    using DentalSystem.Infrastructure;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DentalSystem.Identity", Version = "v1" });
                })
                .AddControllers();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => (env.IsDevelopment()
                    ? app
                        .UseSwagger()
                        .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DentalSystem.Identity v1"))
                    : app
                )
                .UseWebService(env);
    }
}
