using VehicleRental.Core.Schema.OrderSchemas.Request;
using VehicleRental.Core.Schema;

namespace VehicleRental.Application.Services.OrderServices.Interfaces
{
    public interface IManagerOrderService
    {
        Task<Result> NewOrder(NewOrderRequest request);
    }
}