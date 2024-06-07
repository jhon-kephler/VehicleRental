using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using VehicleRental.Data;
using VehicleRental.Infrastructure;

namespace VehicleRental.API
{
    public class Startup : IStartup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer(); 

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("vehicle", new OpenApiInfo
                {
                    Title = "Vehicle API",
                    Version = "v1"
                });

                c.SwaggerDoc("order", new OpenApiInfo
                {
                    Title = "Order API",
                    Version = "v1"
                });

                c.SwaggerDoc("renter", new OpenApiInfo
                {
                    Title = "Renter API",
                    Version = "v1"
                });
            });

            services.AddApplication();
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(); 
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/vehicle/swagger.json", "Vehicle API");
                    c.SwaggerEndpoint("/swagger/order/swagger.json", "Order API");
                    c.SwaggerEndpoint("/swagger/renter/swagger.json", "Renter API");
                });
            }

            app.UseAuthorization();

            app.MapControllers();
        }
    }

    public interface IStartup
    {
        IConfiguration Configuration { get; }
        void ConfigureServices(IServiceCollection services);
        void Configure(WebApplication app, IWebHostEnvironment environment);
    }

    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder webAppBuilder) where TStartup : IStartup
        {
            var startup = Activator.CreateInstance(typeof(TStartup), webAppBuilder.Configuration) as IStartup;
            if (startup == null) throw new Exception("Invalid Startup");

            startup.ConfigureServices(webAppBuilder.Services);

            var objBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, false);

            var config = objBuilder.Build();

            var connection = config["ConnectionString:DefaultConnection"];

            webAppBuilder.Services.AddDbContext<VehicleRentalContext>(options => { options.UseNpgsql(connection); });

            var app = webAppBuilder.Build();

            startup.Configure(app, app.Environment);

            app.Run();

            return webAppBuilder;
        }
    }
}
