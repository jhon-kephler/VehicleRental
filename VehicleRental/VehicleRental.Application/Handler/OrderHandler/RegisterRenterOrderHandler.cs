using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRental.Application.Services.RenterServices.Interfaces;
using VehicleRental.Core.Schema.RenterSchemas.RegisterRenterSchema.Request;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.OrderSchemas.Request;
using VehicleRental.Application.Services.OrderServices.Interfaces;

namespace VehicleRental.Application.Handler.OrderHandler
{
    public class RegisterRenterOrderHandler : IRequestHandler<NewOrderRequest, Result>
    {
        private readonly IManagerOrderService _managerOrderService;

        public RegisterRenterOrderHandler(IManagerOrderService managerOrderService)
        {
            _managerOrderService = managerOrderService;
        }

        public async Task<Result> Handle(NewOrderRequest request, CancellationToken cancellationToken) =>
                            await _managerOrderService.NewOrder(request);
    }
}