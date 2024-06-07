using MediatR;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.VehicleSchema.Request;
using VehicleRental.Application.Services.AdminVehicle.Interfaces;

namespace VehicleRental.Application.Handler
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
