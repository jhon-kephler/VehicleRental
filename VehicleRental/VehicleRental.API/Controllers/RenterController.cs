using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.RenterSchemas.RegisterRenterSchema.Request;
using VehicleRental.Core.Schema.RenterSchemas.SearchRenterSchema.Request;
using VehicleRental.Core.Schema.RenterSchemas.SearchRenterSchema.Response;

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
        public Task<Result<SearchRentalResponse>> GetRenterbyId([FromQuery] SearchRentalByIdRequest request) =>
            _mediator.Send(request);

        [HttpGet("Cnh")]
        public Task<Result<SearchRentalResponse>> GetRenterbyCnh([FromQuery] SearchRentalByCnhRequest request) =>
            _mediator.Send(request);

        [HttpGet("Document")]
        public Task<Result<SearchRentalResponse>> GetRenterbyDocument([FromQuery] SearchRentalByDocumentRequest request) =>
            _mediator.Send(request);

        [HttpPost()]
        public Task<Result> PostNewRenter(RegisterRenterRequest request) =>
            _mediator.Send(request);

        [HttpPost("Cnh")]
        public Task<Result> PostCnhRenter(InsertRentalCNHRequest request) =>
            _mediator.Send(request);
    }
}
