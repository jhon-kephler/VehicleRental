using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VehicleRental.Data;
using VehicleRental.Data.Command.VehicleCommand;
using VehicleRental.Data.Command.VehicleCommand.Interfaces;
using VehicleRental.Data.Repositories;
using VehicleRental.Domain.Repositories;
using VehicleRental.Application.Services.AdminVehicle;
using VehicleRental.Application.Services.AdminVehicle.Interfaces;
using VehicleRental.Data.Query.VehicleQuery.Interfaces;
using VehicleRental.Data.Query.VehicleQuery;
using VehicleRental.Data.Query.BrandQuery.Interfaces;
using VehicleRental.Data.Query.brandQuery;

namespace VehicleRental.Infrastructure
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddRepository();
            services.AddHandler();
            services.AddServices();
            services.AddCommand();
            services.AddQuery();

            return services;
        }

        public static IServiceCollection AddHandler(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly));
            services.AddAutoMapper(Application.AssemblyReference.Assembly);

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IManageVehicleService, ManageVehicleService>();
            services.AddScoped<ISearchVehicleService, SearchVehicleService>();
            return services;
        }

        public static IServiceCollection AddCommand(this IServiceCollection services)
        {
            services.AddScoped(typeof(ISaveVehicleCommand), typeof(SaveVehicleCommand));
            services.AddScoped(typeof(IUpdateVehicleCommand), typeof(UpdateVehicleCommand));
            services.AddScoped(typeof(IDeleteVehicleCommand), typeof(DeleteVehicleCommand));
            return services;
        }

        public static IServiceCollection AddQuery(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGetVehicleByIdQuery), typeof(GetVehicleByIdQuery));
            services.AddScoped(typeof(IGetBrandByIdQuery), typeof(GetBrandByIdQuery));
            services.AddScoped(typeof(IGetBrandByNameQuery), typeof(GetBrandByNameQuery));
            services.AddScoped(typeof(IGetVehicleByPlateQuery), typeof(GetVehicleByPlateQuery));
            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(DbContext), typeof(VehicleRentalContext));
            return services;
        }
    }
}
