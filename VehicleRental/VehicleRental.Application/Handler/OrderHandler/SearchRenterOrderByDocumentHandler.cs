using MediatR;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.OrderSchemas.Request;
using VehicleRental.Application.Services.OrderServices.Interfaces;
using VehicleRental.Core.Schema.OrderSchemas.Response;

namespace VehicleRental.Application.Handler.OrderHandler
{
    public class SearchRenterOrderByDocumentHandler : IRequestHandler<SearchOrderByDocumentRequest, Result<OrderResponse>>
    {
        private readonly ISearchOrderService _searchOrderService;

        public SearchRenterOrderByDocumentHandler(ISearchOrderService searchOrderService)
        {
            _searchOrderService = searchOrderService;
        }

        public async Task<Result<OrderResponse>> Handle(SearchOrderByDocumentRequest request, CancellationToken cancellationToken) =>
                            await _searchOrderService.SearchOrderByDocument(request);
    }
}