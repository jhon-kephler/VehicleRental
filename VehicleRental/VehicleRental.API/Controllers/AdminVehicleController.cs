using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.DeleteVehicleSchema.Request;
using VehicleRental.Core.Schema.PlateSchema.Request;
using VehicleRental.Core.Schema.VehicleSchema.Request;
using VehicleRental.Core.Schema.VehicleSchema.Response;

namespace VehicleRental.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminVehicleController : ControllerBase
    {
        private readonly ILogger<AdminVehicleController> _logger;
        private readonly IMediator _mediator;

        public AdminVehicleController(ILogger<AdminVehicleController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet()]
        public Task<Result<SearchVehicleResponse>> Get(SearchVehicleByIdRequest request) =>
            _mediator.Send(request);

        [HttpGet("plate")]
        public Task<Result<SearchVehicleResponse>> Get(SearchVehicleByPlateRequest request) =>
            _mediator.Send(request);

        [HttpPost("vehicle")]
        public Task<Result> PostNewVehicle(VehicleRequest request) =>
            _mediator.Send(request);

        [HttpPost("plate")]
        public Task<Result> PostPlate(PlateRequest request) =>
            _mediator.Send(request);

        [HttpDelete("vehicle")]
        public Task<Result> DeleteVehicle(DeleteVehicleRequest request) =>
            _mediator.Send(request);
    }
}