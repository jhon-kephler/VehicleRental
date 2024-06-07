using MediatR;
using VehicleRental.Core.Schema;
using VehicleRental.Application.Services.VehicleServices.Interfaces;
using VehicleRental.Core.Schema.VehicleSchemas.PlateSchema.Request;
using VehicleRental.Core.Schema.VehicleSchemas.DeleteVehicleSchema.Request;

namespace VehicleRental.Application.Handler.VehicleHandler
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
