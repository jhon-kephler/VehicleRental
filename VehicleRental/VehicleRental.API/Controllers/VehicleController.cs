﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.VehicleSchemas.DeleteVehicleSchema.Request;
using VehicleRental.Core.Schema.VehicleSchemas.PlateSchema.Request;
using VehicleRental.Core.Schema.VehicleSchemas.VehicleSchema.Request;
using VehicleRental.Core.Schema.VehicleSchemas.VehicleSchema.Response;

namespace VehicleRental.API.Controllers
{
    [ApiController]
    [Route("api/vehicle/[controller]")]
    [ApiExplorerSettings(GroupName = "vehicle")]
    public class VehicleController : ControllerBase
    {
        private readonly ILogger<VehicleController> _logger;
        private readonly IMediator _mediator;

        public VehicleController(ILogger<VehicleController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet()]
        public Task<Result<SearchVehicleResponse>> Get([FromQuery] SearchVehicleByIdRequest request) =>
            _mediator.Send(request);

        [HttpPost()]
        public Task<Result> PostNewVehicle(VehicleRequest request) =>
            _mediator.Send(request);

        [HttpDelete()]
        public Task<Result> DeleteVehicle([FromQuery] DeleteVehicleRequest request) =>
            _mediator.Send(request);

        [HttpGet("Plate")]
        public Task<Result<SearchVehicleResponse>> Get([FromQuery] SearchVehicleByPlateRequest request) =>
            _mediator.Send(request);

        [HttpPost("Plate")]
        public Task<Result> PostPlate(PlateRequest request) =>
            _mediator.Send(request);
    }
}