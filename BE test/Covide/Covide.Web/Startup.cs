using Covide.Web.Data.DbContexts;
using Covide.Web.Services.Interfaces;
using Covide.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Covide.Web.Services.Conversions;
using Covide.Web.Models;

namespace Covide.Web
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

            // Add database context with SQLite
            services.AddEntityFrameworkSqlite().AddDbContext<CovideDataContext>();

            services.AddTransient<IColorConversionStrategy<RgbColor>, HexToRgbConverter>();
            services.AddTransient<IColorConversionStrategy<CmykColor>, RgbToCmykConverter>();
            services.AddTransient<IColorConversionStrategy<HslColor>, RgbToHslConverter>();
            services.AddTransient<IColorConversionStrategy<HsvColor>, RgbToHsvConverter>();
            services.AddTransient<IColorConversionStrategy<XyzColor>, RgbToXyzConverter>();

            services.AddMemoryCache();
            services.AddSingleton<ColorConversionFactory>();
            services.AddScoped<IColorConversionService, ColorConversionService>();

            // Register Swagger generator for API documentation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Color Converter API",
                    Version = "v1",
                    Description = "API for converting color codes to various formats"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Color Converter API v1");
                    c.RoutePrefix = string.Empty; // Sets Swagger UI as the root
                });
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
