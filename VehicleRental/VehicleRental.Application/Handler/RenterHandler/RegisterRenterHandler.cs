using MediatR;
using VehicleRental.Application.Services.RenterServices.Interfaces;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.RenterSchemas.RegisterRenterSchema.Request;

namespace VehicleRental.Application.Handler.RenterHandler
{
    public class RegisterRenterHandler : IRequestHandler<RegisterRenterRequest, Result>
    {
        public readonly IManagerRenterService _managerRenterService;

        public RegisterRenterHandler(IManagerRenterService managerRenterService)
        {
            _managerRenterService = managerRenterService;
        }

        public async Task<Result> Handle(RegisterRenterRequest request, CancellationToken cancellationToken) =>
                            await _managerRenterService.CreateRenter(request);
    }
}
