using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleRental.Core.Schema;
using VehicleRental.Core.Schema.OrderSchemas.Request;
using VehicleRental.Core.Schema.OrderSchemas.Response;

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
        public Task<Result<OrderResponse>> Get([FromQuery] SearchOrderByIdRequest request) =>
                _mediator.Send(request);

        [HttpGet("Document")]
        public Task<Result<OrderResponse>> GetByDocument([FromQuery] SearchOrderByDocumentRequest request) =>
                _mediator.Send(request);

        [HttpGet("Cnh")]
        public Task<Result<OrderResponse>> GetByCnh([FromQuery] SearchOrderByCnhRequest request) =>
                _mediator.Send(request);

        [HttpPost()]
        public Task<Result> Post(NewOrderRequest request) =>
            _mediator.Send(request);
    }
}
