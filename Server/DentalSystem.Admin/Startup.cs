namespace DentalSystem.Admin
{
    using System.Reflection;
    using DentalSystem.Admin.Infrastructure;
    using DentalSystem.Admin.Services;
    using DentalSystem.Admin.Services.Identity;
    using DentalSystem.Admin.Services.Scheduling;
    using DentalSystem.Infrastructure;
    using DentalSystem.Services.Identity;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Refit;

    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var serviceEndpoints = this.Configuration
                .GetSection(nameof(ServiceEndpoints))
                .Get<ServiceEndpoints>(config => config.BindNonPublicProperties = true);

            services
                .AddAutoMapperProfile(Assembly.GetExecutingAssembly())
                .AddTokenAuthentication(this.Configuration)
                .AddHealth(
                    this.Configuration,
                    databaseHealthChecks: false,
                    messagingHealthChecks: false)
                .AddScoped<ICurrentTokenService, CurrentTokenService>()
                .AddTransient<JwtCookieAuthenticationMiddleware>()
                .AddControllersWithViews(options => options
                    .Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

            services
                .AddRefitClient<IIdentityService>()
                .WithConfiguration(serviceEndpoints.Identity);

            services
                .AddRefitClient<ITreatmentSessionService>()
                .WithConfiguration(serviceEndpoints.Scheduling);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) =>
            (env.IsDevelopment()
                ? app.UseDeveloperExceptionPage()
                : app.UseExceptionHandler("/Home/Error")
                    .UseHsts())
            .UseHttpsRedirection()
            .UseStaticFiles()
            .UseRouting()
            .UseJwtCookieAuthentication()
            .UseAuthorization()
            .UseEndpoints(endpoints => endpoints
                .MapHealthChecks()
                .MapDefaultControllerRoute());
    }
}
