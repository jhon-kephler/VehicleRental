using MediatR;
using VehicleRental.Core.Schema;
using VehicleRental.Application.Services.AdminVehicle.Interfaces;
using VehicleRental.Core.Schema.PlateSchema.Request;

namespace VehicleRental.Application.Handler
{
    public class UpdatePlateHandler : IRequestHandler<PlateRequest, Result>
    {
        private readonly IManageVehicleService _manageVehicleService;

        public UpdatePlateHandler(IManageVehicleService manageVehicleService)
        {
            _manageVehicleService = manageVehicleService;
        }

        public async Task<Result> Handle(PlateRequest request, CancellationToken cancellationToken) =>
                                await _manageVehicleService.UpdatePlate(request);
    }
}
