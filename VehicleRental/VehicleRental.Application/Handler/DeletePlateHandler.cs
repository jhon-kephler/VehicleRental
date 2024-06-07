using MediatR;
using VehicleRental.Core.Schema;
using VehicleRental.Application.Services.AdminVehicle.Interfaces;
using VehicleRental.Core.Schema.PlateSchema.Request;
using VehicleRental.Core.Schema.DeleteVehicleSchema.Request;

namespace VehicleRental.Application.Handler
{
    public class DeletePlateHandler : IRequestHandler<DeleteVehicleRequest, Result>
    {
        private readonly IManageVehicleService _manageVehicleService;

        public DeletePlateHandler(IManageVehicleService manageVehicleService)
        {
            _manageVehicleService = manageVehicleService;
        }

        public async Task<Result> Handle(DeleteVehicleRequest request, CancellationToken cancellationToken) =>
                                await _manageVehicleService.DeleteVehicle(request);
    }
}
