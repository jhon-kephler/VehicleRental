using MediatR;
using VehicleRental.Core.Schema;
using VehicleRental.Application.Services.VehicleServices.Interfaces;
using VehicleRental.Core.Schema.VehicleSchemas.VehicleSchema.Request;

namespace VehicleRental.Application.Handler.VehicleHandler
{
    public class CreateNewVehicleHandler : IRequestHandler<VehicleRequest, Result>
    {
        private readonly IManageVehicleService _manageVehicleService;

        public CreateNewVehicleHandler(IManageVehicleService manageVehicleService)
        {
            _manageVehicleService = manageVehicleService;
        }

        public async Task<Result> Handle(VehicleRequest request, CancellationToken cancellationToken) =>
                                await _manageVehicleService.CreateNewVehicle(request);
    }
}
