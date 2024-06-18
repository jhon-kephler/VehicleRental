using MediatR;
using VehicleRental.Application.Services.RenterServices.Interfaces;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.RenterSchemas.RegisterRenterSchema.Request;
using VehicleRental.Core.Schema.RenterSchemas.SearchRenterSchema.Request;
using VehicleRental.Core.Schema.RenterSchemas.SearchRenterSchema.Response;

namespace VehicleRental.Application.Handler.RenterHandler
{
    public class SearchRenterByDocumentHandler : IRequestHandler<SearchRentalByDocumentRequest, Result<SearchRentalResponse>>
    {
        private readonly ISearchRentalService _searchRentalService;

        public SearchRenterByDocumentHandler(ISearchRentalService searchRentalService)
        {
            _searchRentalService = searchRentalService;
        }

        public async Task<Result<SearchRentalResponse>> Handle(SearchRentalByDocumentRequest request, CancellationToken cancellationToken) =>
                            await _searchRentalService.SearchRentalByDocument(request);
    }
}
