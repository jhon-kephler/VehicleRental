using MediatR;
using VehicleRental.Application.Services.RenterServices.Interfaces;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.RenterSchemas.RegisterRenterSchema.Request;

namespace VehicleRental.Application.Handler.RenterHandler
{
    public class InsertCnhRenterHandler : IRequestHandler<InsertRentalCNHRequest, Result>
    {
        public readonly IManagerRenterService _managerRenterService;

        public InsertCnhRenterHandler(IManagerRenterService managerRenterService)
        {
            _managerRenterService = managerRenterService;
        }

        public async Task<Result> Handle(InsertRentalCNHRequest request, CancellationToken cancellationToken) =>
                            await _managerRenterService.InsertCnh(request);
    }
}
