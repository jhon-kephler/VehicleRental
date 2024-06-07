using MediatR;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.VehicleSchema.Request;
using VehicleRental.Application.Services.AdminVehicle.Interfaces;
using VehicleRental.Core.Schema.VehicleSchema.Response;
using VehicleRental.Application.Services.AdminVehicle;

namespace VehicleRental.Application.Handler
{
    public class SearchVehicleByIdHandler : IRequestHandler<SearchVehicleByIdRequest, Result<SearchVehicleResponse>>
    {
        private readonly ISearchVehicleService _searchVehicleService;

        public SearchVehicleByIdHandler(ISearchVehicleService searchVehicleService)
        {
            _searchVehicleService = searchVehicleService;
        }

        public async Task<Result<SearchVehicleResponse>> Handle(SearchVehicleByIdRequest request, CancellationToken cancellationToken) =>
                                await _searchVehicleService.SearchVehicleById(request);
    }
}
