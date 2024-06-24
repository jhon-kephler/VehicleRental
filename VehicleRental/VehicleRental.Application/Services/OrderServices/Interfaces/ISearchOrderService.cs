using VehicleRental.Core.Schema.OrderSchemas.Request;
using VehicleRental.Core.Schema.OrderSchemas.Response;
using VehicleRental.Core.Schema;

namespace VehicleRental.Application.Services.OrderServices.Interfaces
{
    public interface ISearchOrderService
    {
        Task<Result<OrderResponse>> SearchOrderById(SearchOrderByIdRequest request);
        Task<Result<OrderResponse>> SearchOrderByDocument(SearchOrderByDocumentRequest request);
        Task<Result<OrderResponse>> SearchOrderByCnh(SearchOrderByCnhRequest request);
    }
}