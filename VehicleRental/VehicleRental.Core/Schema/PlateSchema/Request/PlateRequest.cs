using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRental.Core.Schema.PlateSchema.Request
{
    public class PlateRequest : IRequest<Result>
    {
        public int VehicleId { get; set; }
        public string Plate { get; set; }
    }
}
