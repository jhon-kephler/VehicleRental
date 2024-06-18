using MediatR;
using VehicleRental.Application.Services.RenterServices.Interfaces;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.RenterSchemas.RegisterRenterSchema.Request;
using VehicleRental.Core.Schema.RenterSchemas.SearchRenterSchema.Request;
using VehicleRental.Core.Schema.RenterSchemas.SearchRenterSchema.Response;

namespace VehicleRental.Application.Handler.RenterHandler
{
    public class SearchRenterByIdHandler : IRequestHandler<SearchRentalByIdRequest, Result<SearchRentalResponse>>
    {
        private readonly ISearchRentalService _searchRentalService;

        public SearchRenterByIdHandler(ISearchRentalService searchRentalService)
        {
            _searchRentalService = searchRentalService;
        }

        public async Task<Result<SearchRentalResponse>> Handle(SearchRentalByIdRequest request, CancellationToken cancellationToken) =>
                            await _searchRentalService.SearchRentalById(request);
    }
}
