using MediatR;
using VehicleRental.Core.Schema;
using VehicleRental.Application.Services.VehicleServices.Interfaces;
using VehicleRental.Core.Schema.VehicleSchemas.VehicleSchema.Request;
using VehicleRental.Core.Schema.VehicleSchemas.VehicleSchema.Response;

namespace VehicleRental.Application.Handler.VehicleHandler
{
    public class SearchVehicleByPlateHandler : IRequestHandler<SearchVehicleByPlateRequest, Result<SearchVehicleResponse>>
    {
        private readonly ISearchVehicleService _searchVehicleService;

        public SearchVehicleByPlateHandler(ISearchVehicleService searchVehicleService)
        {
            _searchVehicleService = searchVehicleService;
        }

        public async Task<Result<SearchVehicleResponse>> Handle(SearchVehicleByPlateRequest request, CancellationToken cancellationToken) =>
                                await _searchVehicleService.SearchVehicleByPlate(request);
    }
}
