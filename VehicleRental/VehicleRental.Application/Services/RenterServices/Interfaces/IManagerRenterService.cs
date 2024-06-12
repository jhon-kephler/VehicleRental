using VehicleRental.Core.Schema.RenterSchemas.RegisterRenterSchema.Request;
using VehicleRental.Core.Schema;

namespace VehicleRental.Application.Services.RenterServices.Interfaces
{
    public interface IManagerRenterService
    {
        Task<Result> CreateRenter(RegisterRenterRequest request);
        Task<Result> InsertCnh(InsertRentalCNHRequest request);
    }
}
