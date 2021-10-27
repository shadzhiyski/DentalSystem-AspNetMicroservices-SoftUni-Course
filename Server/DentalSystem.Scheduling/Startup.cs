namespace DentalSystem.Scheduling
{
    using DentalSystem.Infrastructure;
    using Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddWebService<SchedulingDbContext>(this.Configuration)
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DentalSystem.Scheduling", Version = "v1" });
                });

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => (env.IsDevelopment()
                    ? app
                        .UseDeveloperExceptionPage()
                        .UseSwagger()
                        .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DentalSystem.Scheduling v1"))
                    : app
                )
                .UseWebService(env)
                .Initialize();
    }
}
