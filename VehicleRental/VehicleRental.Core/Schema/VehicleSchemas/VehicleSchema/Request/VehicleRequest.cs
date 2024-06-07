using MediatR;
using VehicleRental.Core.Schema.VehicleSchemas.VehicleSchema.Response;

namespace VehicleRental.Core.Schema.VehicleSchemas.VehicleSchema.Request
{
    public class VehicleRequest : IRequest<Result>
    {
        public int Year_Vehicle { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
        public string Status { get; set; }
        public bool Availability { get; set; }
    }
}
