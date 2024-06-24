using MediatR;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.OrderSchemas.Request;
using VehicleRental.Application.Services.OrderServices.Interfaces;
using VehicleRental.Core.Schema.OrderSchemas.Response;

namespace VehicleRental.Application.Handler.OrderHandler
{
    public class SearchRenterOrderByCnhHandler : IRequestHandler<SearchOrderByCnhRequest, Result<OrderResponse>>
    {
        private readonly ISearchOrderService _searchOrderService;

        public SearchRenterOrderByCnhHandler(ISearchOrderService searchOrderService)
        {
            _searchOrderService = searchOrderService;
        }

        public async Task<Result<OrderResponse>> Handle(SearchOrderByCnhRequest request, CancellationToken cancellationToken) =>
                            await _searchOrderService.SearchOrderByCnh(request);
    }
}