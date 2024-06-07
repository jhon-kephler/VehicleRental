using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleRental.Core.Schema.VehicleSchemas.VehicleSchema.Response;

namespace VehicleRental.Core.Schema.VehicleSchemas.VehicleSchema.Request
{
    public class SearchVehicleByPlateRequest : IRequest<Result<SearchVehicleResponse>>
    {
        public string Plate { get; set; }
    }
}
