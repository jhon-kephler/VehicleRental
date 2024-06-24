using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRental.Core.Schema.OrderSchemas.Response;

namespace VehicleRental.Core.Schema.OrderSchemas.Request
{
    public class SearchOrderByIdRequest : IRequest<Result<OrderResponse>>
    {
        public int Order_Id { get; set; }
    }
}
