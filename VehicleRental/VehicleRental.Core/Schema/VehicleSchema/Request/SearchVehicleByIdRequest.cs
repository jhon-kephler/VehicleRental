using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRental.Core.Schema.VehicleSchema.Response;

namespace VehicleRental.Core.Schema.VehicleSchema.Request
{
    public class SearchVehicleByIdRequest : IRequest<Result<SearchVehicleResponse>>
    {
        public int Vehicle_Id { get; set; }
    }
}
