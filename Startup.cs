using System;
using EFCore_Multi_BD.Context;
using EFCore_Multi_BD.Interfaces.Entity;
using EFCore_Multi_BD.Interfaces.Repositories;
using EFCore_Multi_BD.Repository;
using EFCore_Multi_BD.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EFCore_Multi_BD
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "GasStation",
                        Version = "v1",
                        Description = "GasStation",
                        Contact = new OpenApiContact
                        {
                            Name = "Andre Lars",
                            Url = new Uri("https://github.com/AndreLars")
                        }
                    });
            });

            services.AddSingleton(Configuration);

            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void RegisterServices(IServiceCollection services)
        {
            if (Configuration.GetSection("DefaultDatabase").Value == "Postgress")
            {
                services.AddDbContext<GasStationContext>(
                    options => options.UseNpgsql(Configuration.GetSection("ConnectionString").Value)
                );
            }
            else
            {
                services.AddDbContext<GasStationContext>(
                    options => options.UseSqlServer(Configuration.GetSection("ConnectionString").Value)
                );
            }

            services.AddScoped<IStationDomainService, StationDomainService>();
            services.AddScoped<IStationRepository, StationRepository>();
        }
    }
}
