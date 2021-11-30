using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Webmotors.Application.Services;
using Webmotors.Domain.Interfaces.Repositories;
using Webmotors.Domain.Interfaces.Services;
using Webmotors.Infrastructure;
using Webmotors.Infrastructure.Repositories;

namespace WebMotors.API
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Webmotors API",
                    Description = "Desafio Webmotors :: TI",
                    Contact = new OpenApiContact
                    {
                        Name = "Jorge Medina",
                        Email = "medicode.developer@gmail.com"
                    }
                });
            });

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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {

                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Webmotors");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
