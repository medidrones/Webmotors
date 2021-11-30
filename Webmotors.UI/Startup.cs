using Blazored.Modal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Webmotors.Application.Services;
using Webmotors.Domain.Interfaces.Repositories;
using Webmotors.Domain.Interfaces.Services;
using Webmotors.Infrastructure;
using Webmotors.Infrastructure.Repositories;
using Webmotors.UI.Data;

namespace Webmotors.UI
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
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<Service>();
            services.AddScoped<WebMotorsAPI>();

            services.AddBlazoredModal();

            services.AddDbContext<WebmotorsContext>(options => options.UseSqlite(@"Data Source = teste_webmotors.db"));

            services.AddScoped<IAdRepository, AdRepository>();
            services.AddScoped<IAdService, AdService>();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
