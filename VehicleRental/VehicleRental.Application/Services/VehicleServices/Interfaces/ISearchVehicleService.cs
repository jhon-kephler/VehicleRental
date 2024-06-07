using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.VehicleSchemas.VehicleSchema.Request;
using VehicleRental.Core.Schema.VehicleSchemas.VehicleSchema.Response;

namespace VehicleRental.Application.Services.VehicleServices.Interfaces
{
    public interface ISearchVehicleService
    {
        Task<Result<SearchVehicleResponse>> SearchVehicleById(SearchVehicleByIdRequest request);
        Task<Result<SearchVehicleResponse>> SearchVehicleByPlate(SearchVehicleByPlateRequest request);
    }
}
