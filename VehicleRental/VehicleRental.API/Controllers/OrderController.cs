using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.VehicleSchemas.VehicleSchema.Request;
using VehicleRental.Core.Schema.VehicleSchemas.VehicleSchema.Response;

namespace VehicleRental.API.Controllers
{
    [ApiController]
    [Route("api/order/[controller]")]
    [ApiExplorerSettings(GroupName = "order")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IMediator _mediator;

        public OrderController(ILogger<OrderController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet()]
        public Task<Result<SearchVehicleResponse>> Get(SearchVehicleByIdRequest request) =>
            _mediator.Send(request);
    }
}
