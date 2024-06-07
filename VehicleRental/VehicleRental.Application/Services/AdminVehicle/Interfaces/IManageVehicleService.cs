using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.VehicleSchema.Request;
using VehicleRental.Core.Schema.PlateSchema.Request;
using VehicleRental.Core.Schema.DeleteVehicleSchema.Request;

namespace VehicleRental.Application.Services.AdminVehicle.Interfaces
{
    public interface IManageVehicleService
    {
        Task<Result> CreateNewVehicle (VehicleRequest request);
        Task<Result> UpdatePlate(PlateRequest request);
        Task<Result> DeleteVehicle(DeleteVehicleRequest request);
    }
}
