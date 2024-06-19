using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VehicleRental.Data;
using VehicleRental.Data.Command.VehicleCommand;
using VehicleRental.Data.Command.VehicleCommand.Interfaces;
using VehicleRental.Data.Repositories;
using VehicleRental.Domain.Repositories;
using VehicleRental.Application.Services.VehicleServices;
using VehicleRental.Application.Services.VehicleServices.Interfaces;
using VehicleRental.Data.Query.VehicleQuery.Interfaces;
using VehicleRental.Data.Query.VehicleQuery;
using VehicleRental.Data.Query.BrandQuery.Interfaces;
using VehicleRental.Data.Query.brandQuery;
using VehicleRental.Data.Command.RenterCommand.Interfaces;
using VehicleRental.Data.Command.RenterCommand;
using VehicleRental.Application.Services.RenterServices.Interfaces;
using VehicleRental.Application.Services.RenterServices;
using VehicleRental.Data.Query.RenterOrderQuery.Interfaces;
using VehicleRental.Data.Query.RenterOrderQuery;
using VehicleRental.Data.Query.RenterQuery.Interfaces;
using VehicleRental.Data.Query.RenterQuery;
using VehicleRental.Application.Services.OrderServices.Interfaces;
using VehicleRental.Application.Services.OrderServices;
using VehicleRental.Data.Command.OrderCommand;

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
            services.AddAutoMapper(Core.AssemblyReference.Assembly);

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IManageVehicleService, ManageVehicleService>();
            services.AddScoped<ISearchVehicleService, SearchVehicleService>();
            services.AddScoped<IManagerRenterService, ManagerRenterService>();
            services.AddScoped<ISearchRentalService, SearchRentalService>();
            services.AddScoped<IManagerOrderService, ManagerOrderService>();
            services.AddScoped<ISearchOrderService, SearchOrderService>();
            return services;
        }

        public static IServiceCollection AddCommand(this IServiceCollection services)
        {
            services.AddScoped(typeof(ISaveVehicleCommand), typeof(SaveVehicleCommand));
            services.AddScoped(typeof(IUpdateVehicleCommand), typeof(UpdateVehicleCommand));
            services.AddScoped(typeof(IDeleteVehicleCommand), typeof(DeleteVehicleCommand));
            services.AddScoped(typeof(ISaveRenterCommand), typeof(SaveRenterCommand));
            services.AddScoped(typeof(ISaveRenterCnhCommand), typeof(SaveRenterCnhCommand));
            services.AddScoped(typeof(ISaveOrderCommand), typeof(SaveOrderCommand));
            return services;
        }

        public static IServiceCollection AddQuery(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGetVehicleByIdQuery), typeof(GetVehicleByIdQuery));
            services.AddScoped(typeof(IGetVehicleByPlateQuery), typeof(GetVehicleByPlateQuery));
            services.AddScoped(typeof(IGetBrandByIdQuery), typeof(GetBrandByIdQuery));
            services.AddScoped(typeof(IGetBrandByNameQuery), typeof(GetBrandByNameQuery));
            services.AddScoped(typeof(IListRenterOrderByRenterIdQuery), typeof(ListRenterOrderByRenterIdQuery));
            services.AddScoped(typeof(IGetRenterByIdQuery), typeof(GetRenterByIdQuery));
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
