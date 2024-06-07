using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRental.Core.Schema.DeleteVehicleSchema.Request
{
    public class DeleteVehicleRequest : IRequest<Result>
    {
        public int VehicleId { get; set; }
    }
}
