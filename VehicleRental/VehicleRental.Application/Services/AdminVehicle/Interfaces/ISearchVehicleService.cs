using VehicleRental.Core.Schema.VehicleSchema.Request;
using VehicleRental.Core.Schema.VehicleSchema.Response;
using VehicleRental.Core.Schema;

namespace VehicleRental.Application.Services.AdminVehicle.Interfaces
{
    public interface ISearchVehicleService
    {
        Task<Result<SearchVehicleResponse>> SearchVehicleById(SearchVehicleByIdRequest request);
        Task<Result<SearchVehicleResponse>> SearchVehicleByPlate(SearchVehicleByPlateRequest request);
    }
}
