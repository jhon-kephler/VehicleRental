using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRental.Core.Schema.VehicleSchemas.DeleteVehicleSchema.Request
{
    public class DeleteVehicleRequest : IRequest<Result>
    {
        public int Vehicle_Id { get; set; }
    }
}
