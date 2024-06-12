using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.RenterSchemas.RegisterRenterSchema.Request;

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

        [HttpPost()]
        public Task<Result> PostNewRenter(RegisterRenterRequest request) =>
            _mediator.Send(request);

        [HttpPost("Cnh")]
        public Task<Result> PostCnhRenter(InsertRentalCNHRequest request) =>
            _mediator.Send(request);
    }
}
