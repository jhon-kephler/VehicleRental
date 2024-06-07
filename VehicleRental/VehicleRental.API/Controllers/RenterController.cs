using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleRental.Core.Schema.VehicleSchema.Request;
using VehicleRental.Core.Schema.VehicleSchema.Response;
using VehicleRental.Core.Schema;

namespace VehicleRental.API.Controllers
{
    [ApiController]
    [Route("api/renter/[controller]")]
    [ApiExplorerSettings(GroupName = "renter")]
    public class RenterController : ControllerBase
    {
        private readonly ILogger<RenterController> _logger;
        private readonly IMediator _mediator;

        public RenterController(ILogger<RenterController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet()]
        public Task<Result<SearchVehicleResponse>> Get(SearchVehicleByIdRequest request) =>
            _mediator.Send(request);
    }
}
