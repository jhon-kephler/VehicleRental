using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.VehicleSchemas.DeleteVehicleSchema.Request;
using VehicleRental.Core.Schema.VehicleSchemas.PlateSchema.Request;
using VehicleRental.Core.Schema.VehicleSchemas.VehicleSchema.Request;

namespace VehicleRental.Application.Services.VehicleServices.Interfaces
{
    public interface IManageVehicleService
    {
        Task<Result> CreateNewVehicle (VehicleRequest request);
        Task<Result> UpdatePlate(PlateRequest request);
        Task<Result> DeleteVehicle(DeleteVehicleRequest request);
    }
}
